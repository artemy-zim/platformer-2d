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
    private float _damageDealt;

    public float DamageDealt => _damageDealt;

    public event Action<float> OnVampireAttackStarted;
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

        while (Time.time < endTime)
        {
            if (damageTaker != null)
                _damageDealt = damageTaker.TakeVampireDamage(_damageAmount);
            else
                _damageDealt = 0;

            damageTaker = _enemyDefiner.GetClosestDamageTaker(_radius);

            yield return null;
        }

        _damageDealt = 0;
        OnVampireAttackStopped?.Invoke();
    }   
}
