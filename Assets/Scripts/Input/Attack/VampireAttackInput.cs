using UnityEngine;

public class VampireAttackInput : BaseInput
{
    public override void Execute()
    {
        if (Input.GetKeyDown(InputConfig.VampireAttackKey))
            AttackInputEvents.InvokeVampireAttackInput();
    }
}
