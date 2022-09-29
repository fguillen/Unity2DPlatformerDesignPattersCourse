using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour, IAgentInput
{
    [field: SerializeField] public Vector2 MovementVector { get; private set; }
    public event Action OnAttack;
    public event Action OnJumpPressed;
    public event Action OnJumpReleased;
    public event Action OnWeaponChange;
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

        if (Input.GetKeyUp(jumpKey))
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
