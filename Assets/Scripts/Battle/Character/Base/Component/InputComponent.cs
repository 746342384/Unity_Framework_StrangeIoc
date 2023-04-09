using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Battle.Character.Base.Component
{
    public class InputComponent : MonoBehaviour, PlayerInput.IPlayerActions
    {
        private PlayerInput PlayerInput;
        public Vector2 MoveValue;

        public event Action JumpEvent;
        public event Action RollForwardEvent;

        private void Start()
        {
            PlayerInput = new PlayerInput();
            PlayerInput.Player.SetCallbacks(this);
            PlayerInput.Enable();
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            MoveValue = context.ReadValue<Vector2>();
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            if (!context.performed) return;
            JumpEvent?.Invoke();
        }

        public void OnRollForward(InputAction.CallbackContext context)
        {
            if (!context.performed) return;
            RollForwardEvent?.Invoke();
        }

        private void OnDisable()
        {
            PlayerInput.Disable();
        }
    }
}