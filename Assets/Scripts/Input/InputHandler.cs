using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);

    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private PlayerJumper _playerJumper;
    [SerializeField] private PlayerAttacker _playerAttacker;

    private void Update()
    {
        HandleMoveInput();
        HandleJumpInput();
        HandleAttackInput();
    }

    private void HandleJumpInput()
    {
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            _playerJumper.TryJump();
    }

    private void HandleMoveInput()
    {
        float direction = Input.GetAxisRaw(Horizontal);

        _playerMover.TryMove(direction);
    }

    private void HandleAttackInput()
    {
        if(Input.GetKeyDown(KeyCode.Z))
            _playerAttacker.TryAttack();
    }
}
