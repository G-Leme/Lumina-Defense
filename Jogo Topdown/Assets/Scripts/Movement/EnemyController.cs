using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float attackRange = 10f;
    private bool canMove;
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float bulletSpeed;
    public float timeBetweenShots = 0.3333f;
    private float timeStamp = 0f;
    public float stopRange = 10f;

   
    GameObject target;
    NavMeshAgent agent;

    void Start()
    {
        

        canMove = true;

        target = PlayerManager.instance.dome;

        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.transform.position, transform.position); 
        if (canMove == true)
        {
            agent.SetDestination(target.transform.position);
        }

        if (distance <= attackRange)
        {
       
            if (Time.time >= timeStamp)
            {
                Attack();
                timeStamp = Time.time + timeBetweenShots;
            }
        }

        if(distance <= stopRange)
        {
            agent.speed = 0f;
            canMove = false;
        }
        else
        {
            agent.speed = 5.5f;
            canMove = true;
        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.DrawWireSphere(transform.position, stopRange);
    }


    private void Attack() 
    {
        var bullet = GameObject.Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

        Destroy(bullet, 2.0f);

    }
}
