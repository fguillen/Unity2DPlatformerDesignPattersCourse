using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    [field: SerializeField] public Vector2 MovementVector { get; private set; }

    public event Action OnAttack, OnJumpPressed, OnJumpReleased, OnWeaponChange;
    public event Action<Vector2> OnMovement;
    public KeyCode jumpKey, attackKey, menuKey;
    public UnityEvent OnMenuKeyPressed;

    void Update()
    {
        if(Time.timeScale > 0)
        {
            GetWeaponChangeInput();
            GetMovementInput();
            GetJumpInput();
            GetAttackInput();

        }

        GetMenuInput();
    }

    void GetWeaponChangeInput()
    {
        if (Input.GetKeyDown(KeyCode.E))
            OnWeaponChange?.Invoke();
    }

    void GetJumpInput()
    {
        if (Input.GetKeyDown(jumpKey))
            OnJumpPressed?.Invoke();

        if (Input.GetKeyDown(jumpKey))
            OnJumpReleased?.Invoke();
    }

    void GetAttackInput()
    {
        if (Input.GetKeyDown(KeyCode.E))
            OnAttack?.Invoke();
    }

    void GetMenuInput()
    {
        if (Input.GetKeyDown(menuKey))
            OnMenuKeyPressed?.Invoke();
    }

    void GetMovementInput()
    {
        MovementVector = GetMovementVector();
        OnMovement?.Invoke(MovementVector);
    }

    protected Vector2 GetMovementVector()
    {
        return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
}
