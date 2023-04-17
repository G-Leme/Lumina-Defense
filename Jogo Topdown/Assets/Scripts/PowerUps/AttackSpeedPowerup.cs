using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Powerups/AttackSpeedBuff")]
public class AttackSpeedPowerup : PowerupEffects
{

    public float multiplier = 1.2f;

    public override void Apply(GameObject player)

    {
        player.GetComponent<PlayerCombat>().timeBetweenShots /= multiplier;
        Debug.Log("Attack Speed!");
    }

}
