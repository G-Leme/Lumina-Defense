using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/DamageBuff")]
public class DamagePowerup : PowerupEffects
{
    public float multiplier = 2;


    public override void Apply(GameObject player)
    {
        player.GetComponent<PlayerCombat>().bulletDamage *= multiplier;
        Debug.Log("Damage Buff!");

    }

}