using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyMelee : MonoBehaviour
{
[SerializeField] private float attackRange = 10f;
[SerializeField] private float attackDamage;
[SerializeField] private float cooldown = 1.5f;
private float timeStamp = 0f;

 [SerializeField] private LayerMask forcefieldLayer;
[SerializeField] private Transform attackPoint;

[SerializeField] Animator animator;

private GameObject target;
private NavMeshAgent agent;


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

}

    private void Attack()
    {
        Collider[] lightHit = Physics.OverlapSphere(attackPoint.position, attackRange, forcefieldLayer);

        foreach (Collider lightArea in lightHit)
        {
            animator.SetBool("attacking", true);
            if (Time.time - timeStamp < cooldown)
            {
                return;
            }
           
            else
            {
                lightArea.GetComponent<LightArea>().TakeDamageLight(attackDamage);
            }
            timeStamp = Time.time;
        }

    }


    }
