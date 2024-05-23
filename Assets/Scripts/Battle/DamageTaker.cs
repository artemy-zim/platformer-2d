using UnityEngine;

public class DamageTaker : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private HitForcer _hitForcer;
    [SerializeField] private ColorChanger _colorChanger;

    public void TakeDamage(float damageAmount, Vector2 enemyPosition)
    {
        _health.TryDealDamage(damageAmount);
        _hitForcer.DoHitForce(enemyPosition);
        _colorChanger.Change();
    }

    public void TakeDamage(float damageAmount)
    {
        _health.TryDealDamage(damageAmount);
    }
}
