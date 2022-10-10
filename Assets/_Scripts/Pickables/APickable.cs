using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class APickable : MonoBehaviour
{
    public abstract void PickUp(Agent agent);
    public UnityEvent OnPicked;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"APickable.OnTriggerEnter2D: {other.gameObject.name}");

        if(other.CompareTag("Player"))
        {
            PickUp(other.GetComponent<Agent>());
            OnPicked?.Invoke();
            Destroy(gameObject);
        }
    }
}
