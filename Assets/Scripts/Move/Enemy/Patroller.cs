using UnityEngine;

public class Patroller : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private TargetMover _targetMover;

    private int _currentWaypointIndex = 0;

    private void Update()
    {
        Patrol();
    }

    private void Patrol()
    {
        Vector2 targetPosition = GetNextWaypointPosition();

        _targetMover.MoveTowards(targetPosition);
    }

    private Vector2 GetNextWaypointPosition()
    {
        int step = 1;

        if (transform.position == _waypoints[_currentWaypointIndex].position)
            _currentWaypointIndex = (_currentWaypointIndex + step) % _waypoints.Length;

        return _waypoints[_currentWaypointIndex].position;
    }
}
