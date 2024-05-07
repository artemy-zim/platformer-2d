using UnityEngine;

public class TargetMover : MonoBehaviour
{
    [SerializeField] private Turner _turner;
    [SerializeField, Range(0, float.MaxValue)] private float _speed;

    public void MoveTowards(Vector2 targetPosition)
    {
        Vector2 currentPosition = transform.position;
        Vector2 direction = targetPosition - currentPosition;

        _turner.TurnTowards(direction.x);

        transform.position = Vector2.MoveTowards(transform.position, targetPosition, _speed * Time.deltaTime);
    }
}
