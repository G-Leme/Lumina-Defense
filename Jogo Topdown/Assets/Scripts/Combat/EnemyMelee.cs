using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyMelee : MonoBehaviour
{
public float attackRange = 10f;
public float attackDamage;
public float cooldown = 1.5f;
private float timeStamp = 0f;

public LayerMask forcefieldLayer;

public Transform attackPoint;
public float stopRange = 10f;

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
        
        
}

private void OnDrawGizmosSelected()
{
    Gizmos.color = Color.red;
    Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    Gizmos.DrawWireSphere(attackPoint.position, stopRange);

}

    private void Attack()
    {
        Collider[] lightHit = Physics.OverlapSphere(attackPoint.position, attackRange, forcefieldLayer);

        foreach (Collider lightArea in lightHit)
        {
          
            if(Time.time - timeStamp < cooldown)
            {
                return;
            }
            timeStamp = Time.time;
                    lightArea.GetComponent<LightArea>().TakeDamageLight(attackDamage);
                                  
        }

    }


    }
