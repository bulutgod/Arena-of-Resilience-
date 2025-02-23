using UnityEngine;
using UnityEngine.AI;


public class EnemyAIController : MonoBehaviour
{
    //Enemy'nin yapay zekas� icin kullan�lan script.
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
            Patrol();//goruste ve sald�r� range'inde degilse devriye atmas� i�in.
        }
        else if (playerInSight && !playerinAttackRange)
        {
            Chase();//g�r�s range'inde oldu�unda ancak attack range'de de�ilse kovalamas� i�in.
        }
        else if (playerInSight && playerinAttackRange)
        {
            EnemyAttack();//g�r�� ve attack range'inde oldu�unda sald�rmas� i�in.
        }
    }

    //enemy'nin chase'lemesi i�in metot.
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
    //enemy'nin hem sald�r� animasyonu i�in hem de sald�rmas� i�in metot.
    public void EnemyAttack()
    {
        if (playerinAttackRange && !animator.GetCurrentAnimatorStateInfo(0).IsName("Zombie Attack"))
        {
            animator.SetTrigger("EnemyAttack");
            agent.SetDestination(transform.position); 
        }

    }
    //enemy'nin devriye atmas� i�in metot.
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
    //enemy'nin player'� aramas� i�in metot.
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
