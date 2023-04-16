using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    private InputMaster _inputMaster;
    private InputAction _moveInput;

    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float gravity = 9.81f;

    private CharacterController _characterController;
    private Transform _thisTransform;

    private void Awake()
    {
        _inputMaster = new InputMaster();
        _moveInput = _inputMaster.Inputs.Move;

        _characterController = GetComponent<CharacterController>();
        _thisTransform = transform;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 inputDirection = _moveInput.ReadValue<Vector2>() * moveSpeed;
        Vector3 moveDirection = (_thisTransform.right * inputDirection.x) + (_thisTransform.forward * inputDirection.y);
        moveDirection *= moveSpeed;

        if (_characterController.isGrounded)
        {
            moveDirection.y = 0;
        }
        else
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        _characterController.Move(moveDirection);
    }

    private void OnEnable()
    {
        _inputMaster.Enable();
    }

    private void OnDisable()
    {
        _inputMaster.Disable();
    }
}
