using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyExplode : MonoBehaviour
{
    public float attackRange;
    public float cooldown = 0.3333f;
    private float timeStamp = 0f;
    public float stopRange = 10f;
    public Transform attackPoint;
    public LayerMask forcefieldLayer;
    public float attackDamage;
    [SerializeField] Animator animator;

    GameObject target;
    NavMeshAgent agent;

    void Start() 
    { 
        target = PlayerManager.instance.dome;

        agent = GetComponent<NavMeshAgent>();
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
            if (Time.time - timeStamp < cooldown)
            {
                return;
            }
            timeStamp = Time.time;
            animator.SetBool("Attacking", true);
            lightArea.GetComponent<LightArea>().TakeDamageLight(attackDamage);
            attackRange = 15f;
           StartCoroutine(Explode());
                     
        }

    }

    IEnumerator Explode()
    {

        
        yield return new WaitForSeconds(2f);
        attackDamage = 1.5f;
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }

   
}