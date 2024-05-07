using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class HitForcer : MonoBehaviour
{
    [SerializeField] private float _hitForce;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void DoHitForce(Vector2 enemyPosition)
    {
        Vector2 position = transform.position;
        Vector2 direction = position - enemyPosition;

        direction.Normalize();

        _rigidbody.AddForce(_hitForce * direction, ForceMode2D.Impulse);
    }
}
