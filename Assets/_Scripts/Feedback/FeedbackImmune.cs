using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedbackImmune : MonoBehaviour
{
    [SerializeField] Collider2D theCollider;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] float durationSeconds = 1f;
    [SerializeField] float blinkDurationSeconds = 0.2f;

    public void Perform()
    {
        StopAllCoroutines();
        ToggleActive(true);
        StartCoroutine(BlinkingCoroutine());
        StartCoroutine(ToggleDeactivateCoroutine());
    }

    void ToggleActive(bool val)
    {
        if(val)
        {
            theCollider.enabled = false;
        } else
        {
            theCollider.enabled = true;
        }
    }

    IEnumerator ToggleDeactivateCoroutine()
    {
        yield return new WaitForSeconds(durationSeconds);
        ToggleActive(false);
    }

    IEnumerator BlinkingCoroutine()
    {
        yield return new WaitForSeconds(blinkDurationSeconds);
        spriteRenderer.enabled = false;
        yield return new WaitForSeconds(blinkDurationSeconds);
        spriteRenderer.enabled = true;

        if(!theCollider.enabled)
            StartCoroutine(BlinkingCoroutine());
    }
}
