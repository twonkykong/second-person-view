using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWalkingNpc : NpcMovement
{
    [SerializeField] private Vector3 randomDestinationPositionRange;

    private void Start()
    {
        Vector3 randomVector = new Vector3(Random.Range(-randomDestinationPositionRange.x, randomDestinationPositionRange.x),
            ThisTransform.position.y,
            Random.Range(-randomDestinationPositionRange.z, randomDestinationPositionRange.z));

        SetDestinationPosition(ThisTransform.position + randomVector);
    }
}
