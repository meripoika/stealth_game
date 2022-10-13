using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    NavMeshAgent Agent;

    public PlayerMovement PM;

    public float aggroDistance;
    public EnemyState state = EnemyState.idle;
    public float chaseTime;
    [SerializeField]bool playerInSight = false;
    public LayerMask layer;

    public Transform[] Points;
    private int destPoint = 0;

    private void Start()
    {
        Agent = GetComponent<NavMeshAgent>();

        Agent.autoBraking = false;
        PatrolState();    
    }

    private void Awake()
    {

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

        if (!Agent.pathPending && Agent.remainingDistance < 0.5f)
            PatrolState();

    }
    void PatrolState()
    {
        if (Points.Length == 0)
            return;

        // Set agent to currently set destination
        Agent.destination = Points[destPoint].position;

        // Choose next point in array as destination, cycle to start if necessary
        destPoint = (destPoint + 1) % Points.Length;
        state = EnemyState.patrol;
    }


    void ChaseState()
    {
        Agent.SetDestination(GameManager.Instance.PlayerObj.transform.position);
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
