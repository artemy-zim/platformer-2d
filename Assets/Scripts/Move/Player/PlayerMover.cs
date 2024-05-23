using System;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private PlayerMoveAnimator _moveAnimator;
    [SerializeField] private Turner _turner;
    [SerializeField, Range(0, float.MaxValue)] private float _speed;

    private void OnEnable()
    {
        MovementInputEvents.OnMoveInput += TryMove;
    }

    private void OnDisable()
    {
        MovementInputEvents.OnMoveInput -= TryMove;
    }

    public void TryMove(float direction)
    {
        int noDirection = 0;

        if (direction != noDirection)
        {
            _turner.TurnTowards(direction);

            _moveAnimator.Play();
        }
        else
        {
            _moveAnimator.Stop();
        }

        transform.Translate(direction * _speed * Time.deltaTime * Vector2.right);
    }
}
