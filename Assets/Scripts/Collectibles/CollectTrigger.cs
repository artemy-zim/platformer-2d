using UnityEngine;

public class CollectTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Player _))
            Destroy(gameObject);
    }
}
