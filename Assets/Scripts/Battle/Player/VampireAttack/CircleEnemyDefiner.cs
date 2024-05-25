using UnityEngine;

public class CircleEnemyDefiner : MonoBehaviour
{
    public DamageTaker GetClosestDamageTaker(float radius)
    {
        Collider2D[] colliders = GetAllColliders(radius);

        DamageTaker closestDamageTaker = null;
        float minSqrDistance = float.MaxValue;

        foreach (Collider2D collider in colliders)
        {
            if (collider != null &&
                collider.gameObject != gameObject && 
                collider.TryGetComponent(out DamageTaker damageTaker))
            {
                float sqrDistance = (transform.position - damageTaker.transform.position).sqrMagnitude;

                if (sqrDistance < minSqrDistance)
                {
                    minSqrDistance = sqrDistance;
                    closestDamageTaker = damageTaker;
                }
            }
        }

        return closestDamageTaker;
    }

    private Collider2D[] GetAllColliders(float radius)
    {
        int collidersMaxAmount = 5;
        Collider2D[] colliders = new Collider2D[collidersMaxAmount];

        Physics2D.OverlapCircleNonAlloc(transform.position, radius, colliders);

        return colliders;
    }
}
