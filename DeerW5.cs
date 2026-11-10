using UnityEngine;
using UnityEngine.AI;

public class DeerW5 : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        if (target != null)
        {
            agent.SetDestination(target.position);
        }
    }
}