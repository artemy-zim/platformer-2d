using UnityEngine;

public class MoveInput : BaseInput
{
    private const string Horizontal = nameof(Horizontal);

    public override void Execute()
    {
        float direction = Input.GetAxisRaw(Horizontal);
        MovementInputEvents.InvokeMoveInput(direction);
    }
}
