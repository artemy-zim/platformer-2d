using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class EnemyAttacker : MonoBehaviour
{
    [SerializeField, Range(0, float.MaxValue)] private float _damageAmount;
    [SerializeField, Range(0, float.MaxValue)] private float _damageCooldown;

    private Player _playerInTrigger;
    private float _lastDamageTime;

    private void FixedUpdate()
    {
        ApplyDamage();  
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.TryGetComponent(out Player player))
            _playerInTrigger = player;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _playerInTrigger = null;
    }

    private void ApplyDamage()
    {
        if( _playerInTrigger != null && Time.time - _lastDamageTime > _damageCooldown)
        {
            if(_playerInTrigger.TryGetComponent(out DamageTaker damageTaker))
            {
                damageTaker.TakeDamage(_damageAmount, transform.position);
                _lastDamageTime = Time.time;
            }
        }
    }
}
