using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class APickable : MonoBehaviour
{
    public abstract void PickUp(Agent agent);
    public UnityEvent OnPicked;

    Collider2D theCollider;
    SpriteRenderer spriteRenderer;

    void Awake()
    {
        theCollider = GetComponent<Collider2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"APickable.OnTriggerEnter2D: {other.gameObject.name}");

        if(other.CompareTag("Player"))
        {
            PickUp(other.GetComponent<Agent>());
            OnPicked?.Invoke();
            DestroyObject();
        }
    }

    void DestroyObject()
    {
        theCollider.enabled = false;
        spriteRenderer.enabled = false;
        Destroy(gameObject, 1f);
    }
}
