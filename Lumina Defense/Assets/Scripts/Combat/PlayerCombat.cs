using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{



    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private float timeBetweenShots = 0.3333f;
    private float timeStamp = 0f;
    public float bulletDamage = 25f;
    [SerializeField] AudioSource shootingSound;
    public bool canShoot;



    private void Start()
    {
     
        canShoot = true;
    }

 
    void FixedUpdate()
    {


        if ((Time.time >= timeStamp) && (Input.GetKey(KeyCode.Mouse0)) && canShoot == true)
        {
         
            Fire();
            timeStamp = Time.time + timeBetweenShots;
        }

    }

    

    private void Fire()
    {
        var bullet = GameObject.Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 25;

        shootingSound.Play();

        Destroy(bullet, 2.0f);
    }

}
