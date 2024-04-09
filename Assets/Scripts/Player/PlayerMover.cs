using System;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private PlayerMoveAnimator _moveAnimator;
    [SerializeField, Min(0)] private float _speed;

    private void OnEnable()
    {
        if (_moveAnimator == null)
        {
            enabled = false;
            throw new ArgumentNullException(nameof(_moveAnimator));
        }
    }

    public void TryMove(float direction)
    {
        int noDirection = 0;

        if (direction != noDirection)
        {
            if (direction < noDirection)
                transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            else
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);

                _moveAnimator.Run();
        }
        else
        {
            _moveAnimator.StopRun();
        }

        transform.Translate(Math.Abs(direction) * _speed * Time.deltaTime * Vector2.right);
    }
}
