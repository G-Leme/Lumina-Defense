using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    public float damage;
    public PlayerCombat playerDmg;
    private void Start()
    {
      playerDmg = GameObject.Find("Player").GetComponent<PlayerCombat>();
  
    }
    private void OnTriggerEnter(Collider collision)
    {
                     
         if(collision.gameObject.TryGetComponent<EnemyStats>(out EnemyStats enemyComponent))
        {
            if (enemyComponent == null)
            {
                return;
            }
            else
            {
                enemyComponent.TakeDamage(playerDmg.bulletDamage);
            }
        }

        Debug.Log("Hit");
        Destroy(gameObject);
    }

  

}
