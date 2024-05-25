using System;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private MoveInput _input;
    [SerializeField] private PlayerMoveAnimator _moveAnimator;
    [SerializeField] private Turner _turner;
    [SerializeField, Range(0, float.MaxValue)] private float _speed;

    private void OnEnable()
    {
        _input.OnMoveInput += TryMove;
    }

    private void OnDisable()
    {
        _input.OnMoveInput -= TryMove;
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
