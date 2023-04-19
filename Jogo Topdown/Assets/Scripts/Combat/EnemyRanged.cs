using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyRanged : MonoBehaviour
{
    public float attackRange;
    private bool canMove;
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float bulletSpeed;
    public float timeBetweenShots = 0.3333f;
    private float timeStamp = 0f;
    public float stopRange = 10f;
    public Transform attackPoint;
    public LayerMask forcefieldLayer;
    public float attackDamage;
    

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

        

                Attack();
               
            
        

        if (distance <= stopRange)
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
        Collider[] lightHit = Physics.OverlapSphere(attackPoint.position, attackRange, forcefieldLayer);

        foreach (Collider lightArea in lightHit)
        {

            Debug.Log("hit");
            lightArea.GetComponent<LightArea>().TakeDamageLight(attackDamage);
            attackRange = 8f;
           StartCoroutine(Explode());
           // var bullet = GameObject.Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);


            // lightArea.GetComponent<PlayerCombat>().tookDamage = true;
            //playerCombat.immunityTime = 0;                    
        }

    }

    IEnumerator Explode()
    {
        
       
        yield return new WaitForSeconds(2f);
        attackDamage = 1.5f;
        Destroy(gameObject);
    }

    private void OnCollisionExit(Collision collision)
    {
        StopCoroutine(Explode());
    }
}