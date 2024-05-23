using System.Collections;
using UnityEngine;

public class PlayerVampireAttacker : MonoBehaviour
{
    [SerializeField] private ClosestEnemyDefiner _enemyDefiner;
    [SerializeField] private Health _playerHealth;
    [SerializeField] private float _damageAmount;
    [SerializeField] private float _attackTime;

    private Coroutine _onDealDamageCoroutine;
    private DamageTaker _currentDamageTaker;

    private void OnEnable()
    {
        AttackInputEvents.OnVampireAttackInput += TryAttack;
    }

    private void OnDisable()
    {
        AttackInputEvents.OnVampireAttackInput -= TryAttack;
    }

    public void TryAttack()
    {
        if (_onDealDamageCoroutine != null)
            StopCoroutine(_onDealDamageCoroutine);

        _currentDamageTaker = _enemyDefiner.GetClosestDamageTaker();
        _onDealDamageCoroutine = StartCoroutine(OnDealDamageCoroutine());
    }

    private IEnumerator OnDealDamageCoroutine()
    {
        float endTime = Time.time + _attackTime;

        while (_currentDamageTaker != null && Time.time < endTime)
        {
            float distance = Vector2.Distance(transform.position, _currentDamageTaker.transform.position);

            if (distance > _enemyDefiner.Radius)
            {
                _currentDamageTaker = _enemyDefiner.GetClosestDamageTaker();

                if (_currentDamageTaker == null)
                    yield break;
            }

            _currentDamageTaker.TakeDamage(_damageAmount);
            _playerHealth.TryHeal(_damageAmount);

            yield return null;
        }
    }
}
