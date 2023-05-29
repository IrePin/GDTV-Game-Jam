using _DrRush.Scripts.FMOD;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    private NavMeshAgent _navMeshAgent;
    [SerializeField] private Transform playerTransform;

    [SerializeField] private GameObject flash;
    //attack 
    public float timeBetweenAttacks;
    public bool alreadyAttacked;
    [SerializeField] private GameObject projectile;
    [SerializeField] private LayerMask whatIsGround, whatIsPlayer;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    private void Awake()
    {
        playerTransform = GameObject.Find("ShooterCapsule").transform;
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        /*if (enemyAwareness.isAggressive)
        {
            navMeshAgent.SetDestination(playerTransform.position);
        }
        else
        {
            navMeshAgent.SetDestination(transform.position);  
        }*/
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        if (playerInSightRange)
        {
            playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        }

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();
    }

    private void AttackPlayer()
    {
        if (!alreadyAttacked && playerInAttackRange)
        {
            //Make sure enemy doesn't move
            _navMeshAgent.SetDestination(transform.position);

            transform.LookAt(playerTransform.position);
            firePoint.LookAt(playerTransform.position);
            ///Attack code here
            Rigidbody rb = Instantiate(projectile, firePoint.transform.position, firePoint.transform.rotation).GetComponent<Rigidbody>();
            Instantiate(flash, firePoint.transform.position, firePoint.transform.rotation);
            rb.AddForce(transform.forward * 22f, ForceMode.Impulse);
            rb.AddForce(transform.up * 8f, ForceMode.Impulse);
            FmodAudioManager.Instance.InitializeRocketLaunch();
            ///End of attack code

            alreadyAttacked = true;
            InvokeRepeating(nameof(ResetAttack), timeBetweenAttacks, timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            _navMeshAgent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomY = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y + randomY, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        _navMeshAgent.SetDestination(playerTransform.position);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
