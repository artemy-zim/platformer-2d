using System;
using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector2 _offset;

    private void OnEnable()
    {
        if(_target == null)
        {
            enabled = false;
            throw new ArgumentNullException(nameof(_target));
        }
    }

    private void LateUpdate()
    {
        Vector3 newPosition = transform.position;

        newPosition.x = _target.position.x + _offset.x;
        newPosition.y = _target.position.y + _offset.y;

        transform.position = newPosition;
    }
}
