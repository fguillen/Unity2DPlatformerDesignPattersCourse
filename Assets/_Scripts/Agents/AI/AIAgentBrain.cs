using System;
using UnityEngine;


namespace AI
{
    public abstract class AIAgentBrain : MonoBehaviour, IAgentInput
    {
        public Vector2 MovementVector { get; set; }
        public event Action OnAttack;
        public event Action OnJumpPressed;
        public event Action OnJumpReleased;
        public event Action OnWeaponChange;
        public event Action<Vector2> OnMovement;

        [HideInInspector] public Agent agent;

        void Awake()
        {
            this.agent = GetComponentInChildren<Agent>();
        }

        public void CallOnAttack()
        {
            OnAttack?.Invoke();
        }

        public void CallOnJumpPressed()
        {
            OnJumpPressed?.Invoke();
        }

        public void CallOnJumpReleased()
        {
            OnJumpReleased?.Invoke();
        }

        public void CallOnWeaponChange()
        {
            OnWeaponChange?.Invoke();
        }

        public void CallOnMovement(Vector2 vector)
        {
            OnMovement?.Invoke(vector);
        }
    }
}
