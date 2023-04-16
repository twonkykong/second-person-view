using UnityEngine;
using DG.Tweening;
using System.Collections;

public class NpcHeadRotation : MonoBehaviour
{
    [SerializeField] private Transform headTransform;

    [SerializeField] private float rangeOfView = 5f;
    [SerializeField] private float headRotationlerpTime = 0.05f;
    [SerializeField] private float stopLookingHeadRotationDuration = 0.25f;

    private Transform _playerTransform;
    private Transform _thisTransform;

    private bool _isLookingAtPlayer;

    private void Awake()
    {
        _thisTransform = transform;
    }

    public void Init(Player player)
    {
        _playerTransform = player.transform;
        StartCoroutine(UpdateCoroutine());
    }

    private IEnumerator UpdateCoroutine()
    {
        while (true)
        {
            RotateHead();

            yield return new WaitForEndOfFrame();
        }
    }   

    private void RotateHead()
    {
        float distance = Vector3.Distance(_thisTransform.position, _playerTransform.position);

        if (distance <= rangeOfView)
        {
            if (!_isLookingAtPlayer) _isLookingAtPlayer = true;

            Vector3 targetDirection = (_playerTransform.position - headTransform.position).normalized;
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            headTransform.rotation = Quaternion.Slerp(headTransform.rotation, targetRotation, headRotationlerpTime);
        }
        else
        {
            if (_isLookingAtPlayer)
            {
                headTransform.DOLocalRotate(Vector3.zero, stopLookingHeadRotationDuration);
                _isLookingAtPlayer = false;
            }
        }
    }
}
