using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class NpcFactory : MonoBehaviour
{
    [SerializeField] private Player player;

    [SerializeField] private GameObject npcPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Vector3 spawnRange;

    [SerializeField] private int npcAmount;

    [SerializeField] private bool previewInEditor;

    private Vector3 _npcSize;
    private int _layermask;

    private void Awake()
    {
        _layermask = LayerMask.GetMask("Npc");
    }

    private Npc SpawnNpc(Vector3 spawnPos)
    {
        return Instantiate(npcPrefab, spawnPos, Quaternion.identity).GetComponent<Npc>();
    }

    private void Start()
    {
        _npcSize = npcPrefab.transform.localScale;
        SpawnNpcs();
    }

    private Vector3 GetRandomSpawnPosition()
    {
        return new Vector3(Random.Range(-spawnRange.x, spawnRange.x), spawnRange.y, Random.Range(-spawnRange.z, spawnRange.z));
    }

    private bool CheckSpawnPosition(Vector3 pos)
    {
        return Physics.BoxCast(pos, _npcSize / 2, Vector3.forward, Quaternion.identity, 999f, _layermask);
    }

    private void SpawnNpcs()
    {
        for (int i = 0; i < npcAmount; i++)
        {
            Vector3 randomPos = GetRandomSpawnPosition();

            while (CheckSpawnPosition(randomPos))
            {
                for (int j = 0; j < 10; j++)
                {
                    randomPos = GetRandomSpawnPosition();
                }

                break;
            }

            if (!CheckSpawnPosition(randomPos))
            {
                Npc newNpc = SpawnNpc(spawnPoint.position + randomPos);
                newNpc.Init(player);
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (previewInEditor)
        {
            Gizmos.DrawWireCube(spawnPoint.position, spawnRange*2f + Vector3.one);
        }
    }
}
