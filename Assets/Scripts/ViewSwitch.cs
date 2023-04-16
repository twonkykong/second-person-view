using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ViewSwitch : MonoBehaviour
{
    private InputMaster _inputMaster;

    [SerializeField] private CameraAnimator cameraAnimator;
    [SerializeField] private ViewSwitchField viewSwitchField;
    [SerializeField] private Transform cameraTransform;

    private Npc _currentNpc;

    private void Awake()
    {
        _inputMaster = new InputMaster();
        _inputMaster.Inputs.SwitchView.performed += _ => SwitchNpc();
    }

    private void SwitchNpc()
    {
        List<Npc> switchableNpcList = viewSwitchField.CheckNpcField();
        if (switchableNpcList == null) return;

        if (switchableNpcList.Contains(_currentNpc))
        {
            switchableNpcList.Remove(_currentNpc);
        }

        _currentNpc = switchableNpcList[Random.Range(0, switchableNpcList.Count)];

        SwitchView();
    }

    private void SwitchView()
    {
        cameraTransform.parent = _currentNpc.CameraPositionGetter;
        cameraTransform.localPosition = Vector3.zero;
        cameraTransform.localEulerAngles = Vector3.zero;

        cameraAnimator.Shake(0.2f, 0.3f);
    }

    private void OnEnable()
    {
        _inputMaster.Enable();
    }

    private void OnDestroy()
    {
        _inputMaster.Inputs.SwitchView.performed -= _ => SwitchNpc();
        _inputMaster.Disable();
    }
}
