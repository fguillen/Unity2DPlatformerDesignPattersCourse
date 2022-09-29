using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Sensors;

public class GroundDetector : MonoBehaviour
{
    List<ObstacleSensor> obstacleSensors;
    Collider2D insideCollider;

    public bool isGrounded { get; private set; }

    void Awake()
    {
        obstacleSensors = GetComponentsInChildren<ObstacleSensor>().ToList();
        insideCollider = GetComponent<Collider2D>();
    }

    // public void DetectGrounded()
    // {
    //     Debug.Log($"DetectGrounded: {Center()}, {Size()}");

    //     RaycastHit2D hit =
    //         Physics2D.BoxCast(
    //             Center(),
    //             Size(),
    //             0f,
    //             Vector2.down,
    //             0f,
    //             groundMask
    //         );

    //     if(hit.collider != null)
    //     {
    //         Debug.Log($"DetectGrounded Hit!");
    //         if(!hit.collider.IsTouching(insideCollider))
    //             isGrounded = true;
    //     }

    //     else
    //         isGrounded = false;
    // }

    public void DetectGrounded()
    {
        isGrounded = false;

        foreach (var obstacleSensor in obstacleSensors)
        {
            if(obstacleSensor.ObstacleFound() && !obstacleSensor.hit.collider.IsTouching(insideCollider))
            {
                isGrounded = true;
                break;
            }
        }
    }
}
