using System;
using UnityEngine;

public class JumpInput : BaseInput
{
    public event Action OnJumpInput;

    public override void Execute()
    {
        foreach (KeyCode keyCode in InputConfig.JumpKeys)
        {
            if (Input.GetKeyDown(keyCode))
                OnJumpInput?.Invoke();
        }
    }
}
