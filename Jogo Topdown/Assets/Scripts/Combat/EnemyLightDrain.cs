using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyLightDrain : MonoBehaviour
{
    public float DrainRange = 1.25f;
    public float attackDamage;
   

    public LayerMask forcefieldLayer;
    private bool canMove;

    public Transform attackPoint;
    public float stopMovementRange = 1.25f;

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




        if (distance <= stopMovementRange)
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
        Gizmos.DrawWireSphere(attackPoint.position, DrainRange);
        Gizmos.DrawWireSphere(attackPoint.position, stopMovementRange);

    }

    private void Attack()
    {
        Collider[] lightHit = Physics.OverlapSphere(attackPoint.position, DrainRange, forcefieldLayer);

        foreach (Collider lightArea in lightHit)
        {

            Debug.Log("hit");
            lightArea.GetComponent<LightArea>().TakeDamageLight(attackDamage);
            DrainRange = 8f;
            stopMovementRange = 100f;
            StartCoroutine(Drain());

            // lightArea.GetComponent<PlayerCombat>().tookDamage = true;
            //playerCombat.immunityTime = 0;                    
        }



    }


    
   IEnumerator Drain() 
    {
        DrainRange = 100f;
        stopMovementRange = 100f;
        yield return new WaitForSeconds(8f);
        DrainRange = 1f;
        yield return new WaitForSeconds(1f);
        stopMovementRange = 1f;
        yield break;
    }

    private void OnCollisionExit(Collision lightArea)
     {
        StopAllCoroutines();
    }


}