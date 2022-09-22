using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.Physics2D;

public class GroundDetector : MonoBehaviour
{
    [SerializeField] BoxCollider2D templateCollider;
    [SerializeField] BoxCollider2D insideCollider;
    [SerializeField] LayerMask groundMask;
    public bool isGrounded;

    public void DetectGrounded()
    {
        RaycastHit2D hit =
            Physics2D.BoxCast(
                (Vector2)templateCollider.bounds.center + templateCollider.offset,
                templateCollider.size,
                0f,
                Vector2.down,
                0f,
                groundMask
            );

        if(hit.collider != null)
        {
            if(!hit.collider.IsTouching(insideCollider))
                isGrounded = true;
        }

        else
            isGrounded = false;
    }


    void OnDrawGizmos()
    {
        Color groundedColor = Color.green;
        Color noGroundedColor = Color.red;
        Gizmos.color = isGrounded ? groundedColor : noGroundedColor;
        Gizmos.DrawWireCube((Vector2)templateCollider.bounds.center + templateCollider.offset, templateCollider.size);
    }
}
