using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentRenderer : MonoBehaviour
{
    float originalScaleX;

    void Awake()
    {
        originalScaleX = Mathf.Abs(transform.parent.localScale.x);
    }

    public void FaceDirection(Vector2 movement)
    {
        if(Mathf.Abs(movement.x) < 0.01f) return;

        float newScaleX = (movement.x < 0f) ? (-1 * originalScaleX) : originalScaleX;

        transform.parent.localScale = new Vector3(newScaleX, transform.parent.localScale.y, transform.parent.localScale.z);
    }
}
