using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerJumper : MonoBehaviour
{
    [SerializeField] private PlayerJumpAnimator _jumpAnimator;
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField, Range(0, float.MaxValue)] private float _jumpForce;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        TryAnimateJump();
    }

    public void TryJump()
    {
        if (_groundChecker.IsJumping == false)
            _rigidbody.AddForce(new Vector2(0f, _jumpForce), ForceMode2D.Impulse);
    }

    private void TryAnimateJump()
    {
        if (_groundChecker.IsJumping == false)
            _jumpAnimator.Stop();
        else
            _jumpAnimator.Play();
    }
}
