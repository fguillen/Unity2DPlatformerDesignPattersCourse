using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAdjustable : MonoBehaviour
{
    [SerializeField] Color gizmoColor = Color.green;
    [SerializeField] bool drawGizmos = true;

    Bounds theBounds;
    BoxCollider2D theCollider;

    void Awake()
    {
        Initialize();
    }

    void Start()
    {
        AdjustCollider();
    }

    void AdjustCollider()
    {
        theCollider.size = ColliderSize();
        theCollider.offset = ColliderOffset();
    }

    void OnDrawGizmos()
    {
        if(!drawGizmos)
            return;

        Initialize();

        Gizmos.color = gizmoColor;
        Gizmos.DrawCube((Vector2)theBounds.center + ColliderOffset(), ColliderSize());
    }

    void Initialize()
    {
        theBounds = transform.GetComponent<Renderer>().bounds;

        if(theCollider == null)
            theCollider = GetComponent<BoxCollider2D>();
    }

    Vector2 ColliderOffset()
    {
        return new Vector2(0f, (theBounds.size.y / 2f) - (theCollider.bounds.size.y / 2f));
    }

    Vector2 ColliderSize()
    {
        return new Vector2(theBounds.size.x, theCollider.bounds.size.y);
    }
}
