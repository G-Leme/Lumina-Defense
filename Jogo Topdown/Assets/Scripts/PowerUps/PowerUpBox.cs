using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBox : MonoBehaviour
{
    public List<PowerupEffects> powerupEffects = new List<PowerupEffects>();
    
    private void OnTriggerEnter(Collider collision)
    {
        int randomPowerup = Random.Range(0, powerupEffects.Count);

        Destroy(gameObject);
        powerupEffects[randomPowerup].Apply(collision.gameObject);
    }
}
