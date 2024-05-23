using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private List<BaseInput> _playerActions;

    private void Update()
    {
        foreach (BaseInput action in _playerActions)
            action.Execute();
    }
}
