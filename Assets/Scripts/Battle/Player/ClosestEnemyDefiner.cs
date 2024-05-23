using UnityEngine;

public class ClosestEnemyDefiner : MonoBehaviour
{
    [SerializeField] private float _radius;

    public float Radius => _radius;

    public DamageTaker GetClosestDamageTaker()
    {
        Collider2D[] colliders = GetAllColliders();

        DamageTaker closestDamageTaker = null;
        float minDistance = float.MaxValue;

        foreach (Collider2D collider in colliders)
        {
            if (collider != null &&
                collider.gameObject != gameObject && 
                collider.TryGetComponent(out DamageTaker damageTaker))
            {
                float distance = Vector2.Distance(transform.position, damageTaker.transform.position);

                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestDamageTaker = damageTaker;
                }
            }
        }

        return closestDamageTaker;
    }

    private Collider2D[] GetAllColliders()
    {
        int collidersMaxAmount = 5;
        Collider2D[] colliders = new Collider2D[collidersMaxAmount];

        Physics2D.OverlapCircleNonAlloc(transform.position, _radius, colliders);

        return colliders;
    }
}
