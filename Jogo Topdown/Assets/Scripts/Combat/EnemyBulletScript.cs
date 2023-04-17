using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    private GameObject player;
    private Rigidbody rb;
    public float force;
    private GameObject target;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
        target = GameObject.FindGameObjectWithTag("LightSource");

        Vector3 direction = target.transform.position - transform.position;
        rb.velocity = new Vector3(direction.x, 0f, direction.z).normalized * force;

       // float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(0, 90, rot);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
        private void OnCollisionEnter(Collision collision)
    {
            if (collision.gameObject.TryGetComponent<LightArea>(out LightArea LightComponnent))
            {
        
                LightComponnent.TakeDamageLight(0.1f);
             //   playerComponent.tookDamage = true;
               // playerComponent.immunityTime = 0;
            
            }

            Destroy(gameObject);

         
    }
}
