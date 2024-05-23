using System;

public static class MovementInputEvents
{
    public static event Action<float> OnMoveInput;
    public static event Action OnJumpInput;

    public static void InvokeMoveInput(float direction) => OnMoveInput?.Invoke(direction);
    public static void InvokeJumpInput() => OnJumpInput?.Invoke();

}
