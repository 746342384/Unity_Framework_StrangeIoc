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

        public bool IsAttacking { get; private set; }
        public bool IsTwoHandAttacking { get; private set; }
        public bool CancelAttacking { get; private set; }
        public bool IsMoveForward { get; private set; }
        public bool IsMoveBaclward { get; private set; }

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
            CancelAttacking = true;
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

        public void OnAttack(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                CancelAttacking = false;
                IsAttacking = true;
            }

            if (context.canceled)
            {
                IsAttacking = false;
            }
        }

        public void OnTwoHandAttack(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                CancelAttacking = false;
                IsTwoHandAttacking = true;
            }

            if (context.canceled)
            {
                IsTwoHandAttacking = false;
            }
        }

        public void OnIsMoveForward(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                IsMoveForward = true;
            }

            if (context.canceled)
            {
                IsMoveForward = false;
            }
        }

        public void OnIsMoveBackward(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                IsMoveBaclward = true;
            }

            if (context.canceled)
            {
                IsMoveBaclward = false;
            }
        }

        public void OnFreeLook(InputAction.CallbackContext context)
        {
            
        }

        private void OnDisable()
        {
            PlayerInput.Disable();
        }
    }
}