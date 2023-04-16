using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimations : MonoBehaviour
{
    private InputMaster _inputMaster;
    private InputAction _moveInput;

    [SerializeField] private Animator animator;

    private void Awake()
    {
        _inputMaster = new InputMaster();
        _moveInput = _inputMaster.Inputs.Move;

        _moveInput.started += _ => SetAnimatorBool("walk", true);
        _moveInput.canceled += _ => SetAnimatorBool("walk", false);
    }

    public void SetAnimatorBool(string boolName, bool value)
    {
        animator.SetBool(boolName, value);
    }

    private void OnEnable()
    {
        _inputMaster.Enable();
    }

    private void OnDisable()
    {
        _moveInput.started -= _ => SetAnimatorBool("walk", true);
        _moveInput.canceled -= _ => SetAnimatorBool("walk", false);
        _inputMaster.Disable();
    }
}
