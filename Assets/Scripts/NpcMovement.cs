using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class NpcMovement : MonoBehaviour
{
    private delegate void StopMovingHandler();
    private StopMovingHandler OnStopMoving;

    [SerializeField] private float velocityToStop = 0.5f;
    [SerializeField] private float stayTime = 3f;

    private NavMeshAgent _navMeshAgent;
    public Transform ThisTransform;

    private Vector3 _destinationPos;
    private bool _isMovingToPoint;

    private void Awake()
    {
        float randomMultiplier = Random.Range(0.8f, 1.6f);

        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.speed = randomMultiplier;
        ThisTransform = transform;
        ThisTransform.localScale *= randomMultiplier;
    }

    public void Init()
    {
        StartCoroutine(MovingStateCheck());
    }

    public void SetDestinationPosition(Vector3 destinationPos)
    {
        _destinationPos = destinationPos;
        _navMeshAgent.destination = _destinationPos;

        _isMovingToPoint = true;
    }

    private IEnumerator MovingStateCheck()
    {
        while (true)
        {
            if (!_isMovingToPoint) yield return 0;

            if (_navMeshAgent.velocity.magnitude <= velocityToStop)
            {
                OnStopMoving?.Invoke();
            }
            yield return new WaitForEndOfFrame();
        }
    }
}
