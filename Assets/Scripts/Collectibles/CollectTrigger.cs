using UnityEngine;

[RequireComponent(typeof(ICollectible))]
public class CollectTrigger : MonoBehaviour
{
    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Player player))
            GetComponent<ICollectible>().Collect(player);
    }
}
