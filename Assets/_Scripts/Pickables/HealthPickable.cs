using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickable : APickable
{
    [SerializeField] int healthBoost = 1;

    public override void PickUp(Agent agent)
    {
        agent.damageManager.AddHealth(healthBoost);
    }
}
