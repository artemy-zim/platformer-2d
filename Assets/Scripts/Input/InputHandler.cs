using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);

    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private PlayerJumper _playerJumper;
    [SerializeField] private PlayerAttacker _playerAttacker;

    private List<KeyCode> _jumpKeyCodes;

    private void Awake()
    {
        FillInJumpKeyCodes();
    }

    private void FillInJumpKeyCodes()
    {
        _jumpKeyCodes = new List<KeyCode>() { KeyCode.W, KeyCode.UpArrow };
    }

    private void Update()
    {
        HandleMove();
        HandleJump();
        HandleAttack();
    }

    private void HandleJump()
    {
        foreach(KeyCode keyCode in _jumpKeyCodes)
        {
            if(Input.GetKeyDown(keyCode)) 
                _playerJumper.TryJump();
        }
    }

    private void HandleMove()
    {
        float direction = Input.GetAxisRaw(Horizontal);

        _playerMover.TryMove(direction);
    }

    private void HandleAttack()
    {
        if (Input.GetKeyDown(KeyCode.Z))
            _playerAttacker.TryAttack();
    }
}
