using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Powerups/ShieldBuff")]
public class ShieldDomePowerup : PowerupEffects
{
    public override void Apply(GameObject player)

    {
      
        Debug.Log("Shield Dome!");
    }
}