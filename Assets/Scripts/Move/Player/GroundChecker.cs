using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Collider2D))]
public class GroundChecker : MonoBehaviour
{
    private List<Collider2D> _colliders = new List<Collider2D>();

    private bool _isJumping;

    public bool IsJumping => _isJumping;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out TilemapCollider2D _))
        {
            _colliders.Add(collision);
            _isJumping = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out TilemapCollider2D _))
        {
            _colliders.Remove(collision);

            if (_colliders.Count == 0)
                _isJumping = true;
        }
    }
}
