using UnityEngine;

[RequireComponent (typeof(CircleCollider2D))]
public class EnemyAttacker : MonoBehaviour
{
    [SerializeField, Range(0, float.MaxValue)] private float _damageAmount;
    [SerializeField, Range(0, float.MaxValue)] private float _damageCooldown;

    private float _lastDamageTime;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(Time.time - _lastDamageTime > _damageCooldown)
        {
            if(collision.TryGetComponent(out Player player))
            {
                player.GetComponent<DamageTaker>().TakeDamage(_damageAmount, transform.position);

                _lastDamageTime = Time.time;
            }
        }
    }
}
