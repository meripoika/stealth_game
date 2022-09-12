using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    NavMeshAgent Agent;

    public float aggroDistance;
    public EnemyState state = EnemyState.idle;
    public float chaseTime;
    bool playerInSight = false;
    public LayerMask layer;


    private void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        switch (state)
        {
            case EnemyState.idle:
                LookForPlayer();
                break;
            case EnemyState.patrol:
                LookForPlayer();
                break;
            case EnemyState.chase:
                ChaseState();
                break;
            case EnemyState.shooting:
                break;
            default:
                break;
        }

    }

    void ChaseState()
    {
        //Agent.SetDestination();
        Debug.Log("zulul");
    }

    void LookForPlayer()
    {
        RaycastHit[] targets = Physics.SphereCastAll(this.transform.position, aggroDistance, transform.forward, 100f, layer);

        foreach (var target in targets)
        {
            if (target.collider.GetComponent<PlayerMovement>())
            {
                RaycastHit hit;
                Vector3 dir = (transform.position - target.collider.transform.position) * -1;

                Debug.DrawRay(transform.position, dir);

                if (Physics.Raycast(transform.position, dir, out hit, Mathf.Infinity))
                {
                    if (hit.collider.GetComponent<PlayerMovement>())
                    {
                        playerInSight = true;
                        state = EnemyState.chase;

                    }
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, aggroDistance);
    }

    public enum EnemyState
    {
        idle,
        patrol,
        chase,
        shooting
    }
}
