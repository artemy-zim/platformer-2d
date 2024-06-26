using UnityEngine;

public class PlayerAttacker : MonoBehaviour
{
    [SerializeField] private Transform _attackerBody;
    [SerializeField] private AttackInput _input;
    [SerializeField] private float _damageAmount;
    [SerializeField] private float _attackDistance;

    private Ray _ray;

    private void OnEnable()
    {
        _input.OnAttackInput += TryAttack;
    }

    private void OnDisable()
    {
        _input.OnAttackInput -= TryAttack;
    }

    public void TryAttack()
    {
        _ray = new Ray(_attackerBody.position, _attackerBody.right);

        RaycastHit2D[] hits = Physics2D.RaycastAll(_ray.origin, _ray.direction, _attackDistance);

        foreach(RaycastHit2D hit in hits)
        {
            if(hit.collider.gameObject != gameObject)
            {
                if(hit.transform.TryGetComponent(out DamageTaker damageTaker))
                {
                    damageTaker.TakeDamage(_damageAmount, transform.position);

                    break;
                }
            }
        }
    }
}
