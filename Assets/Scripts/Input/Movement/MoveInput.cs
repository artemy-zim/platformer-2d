using System;
using UnityEngine;

public class MoveInput : BaseInput
{
    private const string Horizontal = nameof(Horizontal);

    public event Action <float> OnMoveInput;

    public override void Execute()
    {
        float direction = Input.GetAxisRaw(Horizontal);

        OnMoveInput?.Invoke(direction);
    }
}
