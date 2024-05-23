using System;

public static class AttackInputEvents
{
    public static event Action OnAttackInput;
    public static event Action OnVampireAttackInput;

    public static void InvokeAttackInput() => OnAttackInput?.Invoke();
    public static void InvokeVampireAttackInput() => OnVampireAttackInput?.Invoke();
}
