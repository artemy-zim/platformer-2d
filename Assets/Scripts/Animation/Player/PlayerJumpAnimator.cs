using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerJumpAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private readonly int _isJumping = Animator.StringToHash("isJumping");

    private void OnEnable()
    {
        if (_animator == null)
        {
            enabled = false;
            throw new ArgumentNullException(nameof(_animator));
        }
    }

    public void Play()
    {
        _animator.SetBool(_isJumping, true);
    }

    public void Stop()
    {
        _animator.SetBool(_isJumping, false);
    }
}
