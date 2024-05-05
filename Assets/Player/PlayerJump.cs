using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private float _jumpForce;
    [SerializeField] private CharacterController _characterController;

    private float _gravity = 14f;
    private float _fallVelocity;

    private void Update()
    {
        jumpUpdate();
    }

    private void FixedUpdate()
    {
        JumpFixedUpdate();
    }

    private void jumpUpdate() 
    { 
        if (_playerMovement.JumpMoveCondition && _characterController.isGrounded)
        {
            _fallVelocity = -_jumpForce;
        }
    }

    private void JumpFixedUpdate()
    {
        _fallVelocity += _gravity * Time.fixedDeltaTime;
        _characterController.Move(Vector3.down * Time.fixedDeltaTime * _fallVelocity);
        if (_characterController.isGrounded)
        {
            _fallVelocity = 0;
        }
    }
}
