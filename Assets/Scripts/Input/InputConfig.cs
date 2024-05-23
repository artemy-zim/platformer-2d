using System.Collections.Generic;
using UnityEngine;

public static class InputConfig
{
    public static KeyCode AttackKey = KeyCode.Z;
    public static KeyCode VampireAttackKey = KeyCode.X;
    public static List<KeyCode> JumpKeys = new List<KeyCode>() { KeyCode.W, KeyCode.UpArrow };
}
