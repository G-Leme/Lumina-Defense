using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LightTurret : MonoBehaviour
{
    [SerializeField] private float attackRange;
    [SerializeField] private Transform attackPoint;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private float cooldown ;
    public float bulletSpeed;
    private float timeStamp = 0f;

    [SerializeField] private LayerMask enemyLayer;

    [SerializeField] private TurretPlacement turretPlacementScript;

    [SerializeField] AudioSource shootingSound;

    void Start()
    {
        
       
        
    }

    // Update is called once per frame
    void Update()
    {

        turretPlacementScript = GameObject.Find("TurretPlacement").GetComponent<TurretPlacement>();

        if(turretPlacementScript == null)
        {
            return;
        }

        if (Time.time >= timeStamp)
            {
            
            Attack();
                timeStamp = Time.time + cooldown;
            }          
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }


    private void Attack()
    {
        Collider[] enemyHit = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayer);

        foreach (Collider enemy in enemyHit)
        {
            var bullet = GameObject.Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

            shootingSound.Play();

            Destroy(bullet, 3.0f);
        }

    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerBoundary>(out PlayerBoundary destroyTurret))
        {
            Debug.Log("Destroy");
            turretPlacementScript.sparkAmount -= 20;
            Destroy(gameObject);
            
        }
        
    }

}  
