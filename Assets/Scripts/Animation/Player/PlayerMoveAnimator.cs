using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerMoveAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private readonly int _isRunning = Animator.StringToHash("isRunning");

    private void OnEnable()
    {
        if(_animator == null)
        {
            enabled = false;
            throw new ArgumentNullException(nameof(_animator));
        }
    }

    public void Run()
    {
        _animator.SetBool(_isRunning, true);
    }

    public void StopRun()
    {
        _animator.SetBool(_isRunning, false);
    }
}