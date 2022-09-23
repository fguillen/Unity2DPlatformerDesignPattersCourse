using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentAnimation : MonoBehaviour
{
    Animator animator;
    AnimationType animationActive;

    void Awake()
    {
        animator = GetComponent<Animator>();
        Debug.Log($"AgentAnimation.animator: {animator}");
    }

    public void PlayAnimation(AnimationType animationType)
    {
        if(animationActive == animationType) return;

        switch (animationType)
        {
            case AnimationType.idle:
                Play("Idle");
                break;

            case AnimationType.run:
                Play("Run");
                break;

            case AnimationType.jump:
                Play("Jump");
                break;

            case AnimationType.fall:
                Play("Fall");
                break;

            case AnimationType.climb:
                Play("Climb");
                break;

            default:
                break;
        }

        animationActive = animationType;
    }

    void Play(string name)
    {
        animator.Play(name, -1, 0f);
    }
}

public enum AnimationType
{
    die,
    hit,
    idle,
    attack,
    run,
    jump,
    fall,
    climb,
    land
}
