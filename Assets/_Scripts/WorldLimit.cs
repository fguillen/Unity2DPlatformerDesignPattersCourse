using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldLimit : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("WorldLimit.OnTriggerEnter2D()");

        Agent agent = collider.gameObject.GetComponentInParent<Agent>();

        if(agent == null)
            throw new Exception("Agent not found in Parent");

        if(agent.CompareTag("Player"))
        {
            agent.damageManager.GetHit(1, collider.bounds.center);
            if(!agent.damageManager.isDead)
                agent.respawnManager.Respawn();
        } else {
            agent.DestroyObject();
        }
    }
}
