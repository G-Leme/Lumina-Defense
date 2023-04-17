using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] float maxHealth = 100f;
    public float currentHealth;
    public bool tookDamage;
    public float immunityTime;
    public float immunityDuration;

    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float timeBetweenShots = 0.3333f;
    private float timeStamp = 0f;
    public float bulletDamage = 25f;

   



    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
       
    }
    void FixedUpdate()
    {
        if (tookDamage == true)
        {
            immunityTime = immunityTime + Time.deltaTime;
            if (immunityTime >= immunityDuration)
            {
                tookDamage = false;
            }
        }


        if ((Time.time >= timeStamp) && (Input.GetKey(KeyCode.Mouse0)))
        {
            Fire();
            timeStamp = Time.time + timeBetweenShots;
        }

    }

    public void TakeDamagePlayer(float damage)
    {
        if (tookDamage == false)
        {
  
            currentHealth -= damage;
        }

        if (currentHealth <= 0)
        {
            Debug.Log("player has died");
        }
    }

    private void Fire()
    {
        var bullet = GameObject.Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 25;

        Destroy(bullet, 2.0f);
    }

}
