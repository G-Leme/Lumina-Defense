using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    private Rigidbody rb;
    public float force;
    private GameObject target;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
       
        target = GameObject.FindGameObjectWithTag("LightSource");

        Vector3 direction = target.transform.position - transform.position;
        rb.velocity = new Vector3(direction.x, 0f, direction.z).normalized * force;

    }

  
    void Update()
    {
        
    }
        private void OnCollisionEnter(Collision collision)
    {
            if (collision.gameObject.TryGetComponent<LightArea>(out LightArea LightComponnent))
            {
        
                LightComponnent.TakeDamageLight(0.5f);
            
            }

            Destroy(gameObject);

         
    }
}
