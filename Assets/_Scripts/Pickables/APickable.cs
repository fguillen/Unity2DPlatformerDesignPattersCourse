using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class APickable : MonoBehaviour
{
    public abstract void PickUp(Agent agent);

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"APickable.OnTriggerEnter2D: {other.gameObject.name}");

        if(other.CompareTag("Player"))
        {
            PickUp(other.GetComponent<Agent>());
            Destroy(gameObject);
        }
    }
}
