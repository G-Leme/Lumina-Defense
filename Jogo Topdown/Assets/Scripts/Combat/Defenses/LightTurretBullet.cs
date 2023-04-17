using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class LightTurretBullet : MonoBehaviour
{
    Rigidbody rb;
    GameObject targets;
    public float force;
    [SerializeField] private float damage;
    void Start()
    {
        rb = GetComponent<Rigidbody>();


        targets = GameObject.FindGameObjectWithTag("Enemy");

      


    }

    // Update is called once per frame
    void Update()
    {
        targets = GameObject.FindGameObjectWithTag("Enemy");
        AttackClosestEnemy();
    }

    private void AttackClosestEnemy()
    {
        float distanceToClosestEnemy = Mathf.Infinity;
        EnemyStats closestEnemy = null;
        EnemyStats[] allEnemies = GameObject.FindObjectsOfType<EnemyStats>();

        foreach(EnemyStats currentEnemy in allEnemies)
        {
            float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
            if(distanceToEnemy < distanceToClosestEnemy)
            {
                distanceToClosestEnemy = distanceToEnemy;
                closestEnemy = currentEnemy;
            }
        }

        if(closestEnemy == null) 
        {
            return;
        }

        Vector3 direction = closestEnemy.transform.position - transform.position;
        rb.velocity = new Vector3(direction.x, 0f, direction.z).normalized * force;
    }

    private void OnTriggerEnter(Collider collision)
 
    {
        if (collision.gameObject.TryGetComponent<EnemyStats>(out EnemyStats enemyComponent))
        {

            enemyComponent.TakeDamage(damage);
            //   playerComponent.tookDamage = true;
            // playerComponent.immunityTime = 0;

        }

        Destroy(gameObject);


    }

    
}
