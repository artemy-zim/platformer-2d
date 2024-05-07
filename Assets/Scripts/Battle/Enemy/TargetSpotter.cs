using UnityEngine;

public class TargetSpotter : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField, Range(0, float.MaxValue)] private float _maxSpotDistance;

    private Ray _ray;
    private bool _isSpotted = false;

    public bool IsSpotted => _isSpotted;

    private void Update()
    {
        TrySpot();
    }

    private void TrySpot()
    {
        _ray = new Ray(transform.position, transform.right);

        RaycastHit2D[] hits = Physics2D.RaycastAll(_ray.origin, _ray.direction, _maxSpotDistance);

        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider.gameObject != gameObject)
            {
                if (hit.transform == target)
                {
                    _isSpotted = true;

                    break;
                }
            }
        }
    }
}
