using UnityEngine;

public class AttackInput : BaseInput
{
    public override void Execute()
    {
        if (Input.GetKeyDown(InputConfig.AttackKey))
            AttackInputEvents.InvokeAttackInput();
    }
}
