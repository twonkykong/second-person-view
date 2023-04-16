using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRotation : MonoBehaviour
{
    private InputMaster _inputMaster;
    private InputAction _lookInput;

    [SerializeField] private Transform body;
    [SerializeField] private Transform head;
    [SerializeField] private float sensitivity = 10f;

    private float _xAngle, _yAngle;

    private void Awake()
    {
        _inputMaster = new InputMaster();
        _lookInput = _inputMaster.Inputs.Look;
    }

    private void Update()
    {
        Look();
    }

    private void Look()
    {
        Vector2 lookAxis = _lookInput.ReadValue<Vector2>();

        _xAngle += lookAxis.x;
        if (_xAngle > 359) _xAngle = 0;
        else if (_xAngle <= 0) _xAngle = 359;

        _yAngle += lookAxis.y;
        _yAngle = Mathf.Clamp(_yAngle + lookAxis.y, -90, 90);

        body.rotation = Quaternion.Euler(0, _xAngle, 0);
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
