using UnityEngine;
using UnityEngine.AI;


public class EnemyAIController : MonoBehaviour
{
    //Enemy'nin yapay zekasý icin kullanýlan script.
    GameObject player;
    NavMeshAgent agent;
    Animator animator;

    [SerializeField] LayerMask groundLayer, playerLayer;

    Vector3 destPoint;
    bool walkpointSet;
    [SerializeField] float range;

    [SerializeField] float sightRange, attackRange;
    bool playerInSight , playerinAttackRange;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GetComponent<GameObject>();
        animator = GetComponent<Animator>();
        player = GameObject.Find("Player");
       
    }

    
    void Update()
    {
        playerInSight = Physics.CheckSphere(transform.position, sightRange, playerLayer);
        playerinAttackRange = Physics.CheckSphere(transform.position, attackRange, playerLayer);

        if (!playerInSight && !playerinAttackRange)
        {
            Patrol();//goruste ve saldýrý range'inde degilse devriye atmasý için.
        }
        else if (playerInSight && !playerinAttackRange)
        {
            Chase();//görüs range'inde olduðunda ancak attack range'de deðilse kovalamasý için.
        }
        else if (playerInSight && playerinAttackRange)
        {
            EnemyAttack();//görüþ ve attack range'inde olduðunda saldýrmasý için.
        }
    }

    //enemy'nin chase'lemesi için metot.
    void Chase()
    {
       
        if (playerinAttackRange)
        {
            EnemyAttack();
        }
        else
        {
            agent.SetDestination(player.transform.position);
        }
    }
    //enemy'nin hem saldýrý animasyonu için hem de saldýrmasý için metot.
    public void EnemyAttack()
    {
        if (playerinAttackRange && !animator.GetCurrentAnimatorStateInfo(0).IsName("Zombie Attack"))
        {
            animator.SetTrigger("EnemyAttack");
            agent.SetDestination(transform.position); 
        }

    }
    //enemy'nin devriye atmasý için metot.
    void Patrol()
    {
        if(!playerInSight) 
    {
            if (!walkpointSet)
            {
                SearchForDest();
            }

            if (walkpointSet)
            {
                agent.SetDestination(destPoint);
            }

            if (Vector3.Distance(transform.position, destPoint) < 10)
            {
                walkpointSet = false;
            }
        }
    }
    //enemy'nin player'ý aramasý için metot.
    void SearchForDest()
    {
        float Z = Random.Range(-range, range);
        float X = Random.Range(-range, range); 
        destPoint = new Vector3(transform.position.x + X, transform.position.y, transform.position.z + Z);

        if(Physics.Raycast(destPoint,Vector3.down,groundLayer))
        {
            walkpointSet = true;
        }
    }
}
