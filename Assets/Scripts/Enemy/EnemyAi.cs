using System;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemyAi : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround;
    public LayerMask whatIsPlayer;

    public Vector3 walkpoint;
    private bool walkPointSet;
    public float walkPointRange;

    public float timeBetweenAttack;
    private bool alreadyAttacked; 

    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAtackRange;


    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAtackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer); 
        
        if (!playerInSightRange && !playerInAtackRange) Patroling();
        if (playerInSightRange && !playerInAtackRange) ChasePlayer();
        if (playerInSightRange && playerInAtackRange) AttackPlayer();
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPont();

        if (walkPointSet)
        {
            agent.SetDestination(walkpoint); 
        }

        Vector3 distanceToWalkPoint = transform.position - walkpoint;

        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false; 
        }
    }

    void SearchWalkPont()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkpoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkpoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true; 
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }
    
    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);
        
        transform.LookAt(player);
        
        
        
        if (!alreadyAttacked)
        {
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttack);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false; 
    }
}
