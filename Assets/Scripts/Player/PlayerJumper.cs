using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerJumper : MonoBehaviour
{
    [SerializeField] private PlayerJumpAnimator _jumpAnimator;
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField, Min(0)] private float _jumpForce;

    private Rigidbody2D _rigidbody;

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
        if(_jumpAnimator == null)
            throw new ArgumentNullException(nameof(_jumpAnimator));

        if(_groundChecker == null)
            throw new ArgumentNullException(nameof(_groundChecker));
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void TryJump()
    {
        if (_groundChecker.IsJumping == false)
            _rigidbody.AddForce(new Vector2(0f, _jumpForce), ForceMode2D.Impulse);
    }

    public void TryAnimateJump()
    {
        if (_groundChecker.IsJumping == false)
            _jumpAnimator.StopJump();
        else
            _jumpAnimator.Jump();
    }
}
