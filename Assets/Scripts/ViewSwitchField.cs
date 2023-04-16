using System.Collections.Generic;
using UnityEngine;

public class ViewSwitchField : MonoBehaviour
{
    [SerializeField] private Transform fieldCenter;
    [SerializeField] private Vector3 fieldSize;
    [SerializeField] private float fieldMaxDistance;

    private Transform _thisTransform;
    int _layermask;

    private void Awake()
    {
        _thisTransform = transform;
        _layermask = LayerMask.GetMask("Npc");
    }

    public List<Npc> CheckNpcField()
    {
        List<Npc> switchableNpcList = new List<Npc>();

        RaycastHit[] hitList = Physics.BoxCastAll(fieldCenter.position, fieldSize/2f, _thisTransform.forward, _thisTransform.rotation, fieldMaxDistance, _layermask);
        foreach (RaycastHit hitInfo in hitList)
        {
            Debug.Log(hitInfo.collider.name);
            Npc switchableNpc = hitInfo.collider.GetComponent<Npc>();
            switchableNpcList.Add(switchableNpc);
        }

        return switchableNpcList;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(fieldCenter.position, fieldSize);
    }
}
