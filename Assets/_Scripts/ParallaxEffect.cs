using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    float movementSpeed;
    Vector3 originalPosition;
    Vector2 offset;

    void Awake()
    {
        originalPosition = transform.position;
        offset = Camera.main.transform.position - transform.position;
        movementSpeed = Mathf.Lerp(0f, 1f, transform.position.z / 20f);

        Debug.Log($"movementSpeed: {movementSpeed}");
    }

    void FixedUpdate()
    {
        transform.position =
            new Vector3(
                offset.x + Camera.main.transform.position.x * movementSpeed,
                offset.y + Camera.main.transform.position.y * movementSpeed,
                originalPosition.z
            );
    }
}
