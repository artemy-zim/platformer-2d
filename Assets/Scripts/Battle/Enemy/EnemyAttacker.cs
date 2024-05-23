using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class EnemyAttacker : MonoBehaviour
{
    [SerializeField, Range(0, float.MaxValue)] private float _damageAmount;
    [SerializeField, Range(0, float.MaxValue)] private float _damageCooldown;

    private Player _playerAttacked;
    private float _lastAttackTime;

    private void FixedUpdate()
    {
        ApplyDamage();  
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.TryGetComponent(out Player player))
            _playerAttacked = player;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _playerAttacked = null;
    }

    private void ApplyDamage()
    {
        if( _playerAttacked != null && Time.time - _lastAttackTime > _damageCooldown)
        {
            if(_playerAttacked.TryGetComponent(out DamageTaker damageTaker))
            {
                damageTaker.TakeDamage(_damageAmount, transform.position);
                _lastAttackTime = Time.time;
            }
        }
    }
}
