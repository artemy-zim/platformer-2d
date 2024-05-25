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

    public float TakeVampireDamage(float damageAmount)
    {
        float damageTaken = Mathf.Min(_health.CurrentHealth, damageAmount);
        _health.TryDealDamage(damageTaken);

        return damageTaken;
    }
}
