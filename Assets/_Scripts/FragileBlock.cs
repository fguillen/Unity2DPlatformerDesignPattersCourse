using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using WeaponSystem;

public class FragileBlock : MonoBehaviour, IHittable
{
    Animator animator;
    public UnityEvent OnHit;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void GetHit(int damage)
    {
        Debug.Log("FragileBlock.GetHit()");

        animator.Play("Broken", -1, 0f);
        OnHit?.Invoke();
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
