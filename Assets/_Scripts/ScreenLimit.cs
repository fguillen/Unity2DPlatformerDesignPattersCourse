using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenLimit : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("ScreenLimit.OnTriggerEnter2D()");

        if(collider.gameObject.CompareTag("Player"))
        {
            Agent agent = collider.gameObject.GetComponent<Agent>();

            agent.damageManager.GetHit(1, collider.bounds.center);

            agent.Die();
        }
    }
}
