using System;
using UnityEngine;

public class AttackInput : BaseInput
{
    public event Action OnAttackInput;

    public override void Execute()
    {
        if (Input.GetKeyDown(InputConfig.AttackKey))
            OnAttackInput?.Invoke();
    }
}
