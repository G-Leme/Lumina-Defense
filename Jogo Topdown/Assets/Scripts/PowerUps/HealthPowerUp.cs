using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/HealthBuff")]
public class HealthPowerUp : PowerupEffects
{
    public float multiplier = 50f;

    public override void Apply(GameObject player)
    {
        player.GetComponent<PlayerCombat>().currentHealth += multiplier;
        Debug.Log("Health!");
    }
}

