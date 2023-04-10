using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Battle.Character.Base.Component
{
    public class InputComponent : MonoBehaviour, PlayerInput.IPlayerActions
    {
        private PlayerInput PlayerInput;
        public Vector2 MoveValue { get; private set; }
        public event Action JumpEvent;
        public event Action RollForwardEvent;
        public event Action RollBackwardEvent;
        public event Action RollLeftEvent;
        public event Action RollRightEvent;

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

        public void OnRollBackward(InputAction.CallbackContext context)
        {
            if (!context.performed) return;
            RollBackwardEvent?.Invoke();
        }

        public void OnRollLeft(InputAction.CallbackContext context)
        {
            if (!context.performed) return;
            RollLeftEvent?.Invoke();
        }

        public void OnRollRight(InputAction.CallbackContext context)
        {
            if (!context.performed) return;
            RollRightEvent?.Invoke();
        }

        private void OnDisable()
        {
            PlayerInput.Disable();
        }
    }
}