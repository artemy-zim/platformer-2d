using System;
using System.Collections;
using UnityEngine;

public class PlayerVampireAttacker : MonoBehaviour
{
    [SerializeField] private VampireAttackInput _input;
    [SerializeField] private CircleEnemyDefiner _enemyDefiner;
    [SerializeField] private CooldownCounter _counter;
    [SerializeField] private float _damageAmount;
    [SerializeField] private float _attackTime;
    [SerializeField] private float _radius;

    private Coroutine _onDealDamageCoroutine;

    public event Action<float> OnVampireAttackStarted;
    public event Action<float> OnVampireAttackDamageDealing;
    public event Action OnVampireAttackStopped;

    private void OnEnable()
    {
        _input.OnVampireAttackInput += TryAttack;
    }

    private void OnDisable()
    {
        _input.OnVampireAttackInput -= TryAttack;
    }

    public void TryAttack()
    {
        if (_counter.CooldownLeft < 0)
        {
            if (_onDealDamageCoroutine != null)
                StopCoroutine(_onDealDamageCoroutine);

            OnVampireAttackStarted?.Invoke(_radius);

            DamageTaker damageTaker = _enemyDefiner.GetClosestDamageTaker(_radius);
            _onDealDamageCoroutine = StartCoroutine(OnDealDamageCoroutine(damageTaker));
        }
    }

    private IEnumerator OnDealDamageCoroutine(DamageTaker damageTaker)
    {
        float endTime = Time.time + _attackTime;

        while (damageTaker != null && Time.time < endTime)
        {
            float distance = Vector2.Distance(transform.position, damageTaker.transform.position);

            if (distance > _radius)
            {
                damageTaker = _enemyDefiner.GetClosestDamageTaker(_radius);

                if (damageTaker == null)
                    break;
            }

            float damageTaken = damageTaker.TakeVampireDamage(_damageAmount);
            OnVampireAttackDamageDealing?.Invoke(damageTaken);

            yield return null;
        }

        OnVampireAttackStopped?.Invoke();
    }   
}
