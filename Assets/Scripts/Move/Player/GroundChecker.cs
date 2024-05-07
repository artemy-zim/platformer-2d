using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Collider2D))]
public class GroundChecker : MonoBehaviour
{
    private bool _isJumping;

    public bool IsJumping => _isJumping;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out TilemapCollider2D _))
            _isJumping = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out TilemapCollider2D _))
            _isJumping = true;
    }
}
