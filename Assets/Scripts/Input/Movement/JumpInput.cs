using UnityEngine;

public class JumpInput : BaseInput
{
    public override void Execute()
    {
        foreach (KeyCode keyCode in InputConfig.JumpKeys)
        {
            if (Input.GetKeyDown(keyCode))
                MovementInputEvents.InvokeJumpInput();
        }
    }
}
