using System;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField, Min(0)] private float _speed;

    private int _currentWaypointIndex = 0;

    private void OnEnable()
    {
        try
        {
            Validate();
        }
        catch(Exception e) 
        {
            enabled = false;
            throw e;
        }
    }

    private void Validate()
    {
        int minWaypointsLength = 2;

        if (_waypoints == null)
            throw new ArgumentNullException(nameof(_waypoints));

        if (_waypoints.Length < minWaypointsLength)
            throw new ArgumentOutOfRangeException(nameof(_waypoints));
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector2 waypointPosition = GetNextWaypointPosition();
        Vector2 currentPosition = transform.position;

        Vector2 direction = waypointPosition - currentPosition;

        if (direction.x < 0)
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        else
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);

        transform.position = Vector2.MoveTowards(transform.position, waypointPosition, _speed * Time.deltaTime);
    }


    private Vector2 GetNextWaypointPosition()
    {
        int step = 1;

        if (transform.position == _waypoints[_currentWaypointIndex].position)
            _currentWaypointIndex = (_currentWaypointIndex + step) % _waypoints.Length;

        return _waypoints[_currentWaypointIndex].position;
    }
}
