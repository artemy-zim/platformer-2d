using UnityEngine;

public class PlayerAttacker : MonoBehaviour
{
    [SerializeField] private float _damageAmount;
    [SerializeField] private float _attackDistance;

    private Ray _ray;

    private void OnEnable()
    {
        AttackInputEvents.OnAttackInput += TryAttack;
    }

    private void OnDisable()
    {
        AttackInputEvents.OnAttackInput -= TryAttack;
    }

    public void TryAttack()
    {
        _ray = new Ray(transform.position, transform.right);

        RaycastHit2D[] hits = Physics2D.RaycastAll(_ray.origin, _ray.direction, _attackDistance);

        foreach(RaycastHit2D hit in hits)
        {
            if(hit.collider.gameObject != gameObject)
            {
                if(hit.transform.TryGetComponent(out Enemy enemy))
                {
                    enemy.GetComponent<DamageTaker>().TakeDamage(_damageAmount, transform.position);

                    break;
                }
            }
        }
    }
}
