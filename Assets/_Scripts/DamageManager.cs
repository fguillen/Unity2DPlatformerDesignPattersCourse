using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using WeaponSystem;

public class DamageManager : MonoBehaviour, IHittable
{
    int maxHealth;
    int currentHealth;

    public UnityEvent<Vector2> OnHit;
    public UnityEvent OnDie;
    public UnityEvent<int> OnMaxHealthSet;
    public UnityEvent<int> OnHealthChange;

    public void Initialize(int maxHealth)
    {
        this.maxHealth = maxHealth;
        currentHealth = maxHealth;
        OnMaxHealthSet?.Invoke(maxHealth);
    }

    public void GetHit(int damage, Vector2 point)
    {
        Debug.Log($"GetHit({damage}, {point})");

        currentHealth -= damage;
        currentHealth = Mathf.Max(0, currentHealth);

        OnHealthChange?.Invoke(currentHealth);

        if(currentHealth == 0)
            OnDie?.Invoke();
        else
            OnHit?.Invoke(point);
    }
}
