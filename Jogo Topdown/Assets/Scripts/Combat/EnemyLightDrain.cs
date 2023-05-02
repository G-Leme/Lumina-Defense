using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyLightDrain : MonoBehaviour
{
    public float DrainRange = 1.25f;
    public float attackDamage;
   

    public LayerMask forcefieldLayer;

    public Transform attackPoint;
    public float stopMovementRange = 1.25f;
    EnemyStats enemyStats;
    [SerializeField] Animator animator;

    GameObject target;
    NavMeshAgent agent;


    void Start()
    {

        agent = GetComponent<NavMeshAgent>();


        target = PlayerManager.instance.dome;

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        float distance = Vector3.Distance(target.transform.position, transform.position);

        agent.SetDestination(target.transform.position);


        Attack();



        if (distance <= stopMovementRange)
        {
            agent.speed = 0f;
            
        }
       
            
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, DrainRange);
        Gizmos.DrawWireSphere(attackPoint.position, stopMovementRange);

    }

    private void Attack()
    {
        Collider[] lightHit = Physics.OverlapSphere(attackPoint.position, DrainRange, forcefieldLayer);

        foreach (Collider lightArea in lightHit)
        {

          
            lightArea.GetComponent<LightArea>().TakeDamageLight(attackDamage);
            DrainRange = 8f;
            stopMovementRange = 100f;       
            StartCoroutine(Drain());                
        }



    }


    
   IEnumerator Drain() 
    {
        DrainRange = 100f;
        stopMovementRange = 100f;
        animator.SetBool("Attacking", true);
        yield return new WaitForSeconds(8f);
        stopMovementRange = 1f;
        DrainRange = 1f;
        yield return new WaitForSeconds(1.5f);
        agent.speed = 8f;       
        animator.SetBool("Attacking", false);
        yield break;
    }

    private void OnCollisionExit(Collision lightArea)
     {
        StopCoroutine(Drain());
    }


}