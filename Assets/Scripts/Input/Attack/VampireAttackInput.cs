using System;
using UnityEngine;

public class VampireAttackInput : BaseInput
{
    public event Action OnVampireAttackInput;

    public override void Execute()
    {
        if (Input.GetKeyDown(InputConfig.VampireAttackKey))
            OnVampireAttackInput?.Invoke();
    }
}
