using System;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);

    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private PlayerJumper _playerJumper;

    private void OnEnable()
    {
        try
        {
            Validate();
        }
        catch (Exception e) 
        {
            enabled = false;
            throw e;
        }
    }

    private void Validate()
    {
        if (_playerJumper == null)
            throw new ArgumentNullException(nameof(_playerJumper));

        if(_playerMover == null)
            throw new ArgumentNullException(nameof(_playerMover));
    }

    private void Update()
    {
        HandleMoveInput();
        HandleJumpInput();
    }

    private void HandleJumpInput()
    {
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            _playerJumper.TryJump();
        }

        _playerJumper.TryAnimateJump();
    }

    private void HandleMoveInput()
    {
        float direction = Input.GetAxisRaw(Horizontal);

        _playerMover.TryMove(direction);
    }
}
