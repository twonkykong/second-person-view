using UnityEngine;

public class Npc : MonoBehaviour
{
    [SerializeField] private NpcMovement npcMovement;
    [SerializeField] private NpcHeadRotation npcHeadRotation;
    [SerializeField] private Transform cameraPosition;

    public Transform CameraPositionGetter { get { return cameraPosition; } }

    public void Init(Player player)
    {
        npcHeadRotation.Init(player);
        npcMovement.Init();
    }

    public void SetDestinationPosition(Vector3 destinationPos)
    {
        npcMovement.SetDestinationPosition(destinationPos);
    }
}
