using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraAnimator : MonoBehaviour
{
    private Transform _thisTransform;

    private void Awake()
    {
        _thisTransform = transform;
    }

    public void Shake(float duration, float strength)
    {
        _thisTransform.DOShakePosition(duration, strength, 50);
    }
}
