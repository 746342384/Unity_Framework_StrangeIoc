using Battle.Character.Base;
using UnityEngine;

namespace Battle.Character.Player.State
{
    public class PlayerIdleState : PlayerStateBase
    {
        private const float FixedTransitionDuration = 0.1f;

        public PlayerIdleState(CharacterBase character) : base(character)
        {
        }

        public override void Enter()
        {
            Debug.Log("PlayerIdleState");
            Character.Animator.CrossFadeInFixedTime("Idle", FixedTransitionDuration);
            Character.InputComponent.JumpEvent += OnJump;
        }

        public override void Tick(float deltaTime)
        {
            if (Character.InputComponent.IsAttacking)
            {
                Character.StateMachine.SwitchState(new PlayerAttackingState(Character, 0));
                return;
            }

            if (Character.InputComponent.IsTwoHandAttacking)
            {
                Character.StateMachine.SwitchState(new PlayerTwoHandAttackingState(Character));
                return;
            }

            if (!Character.InputComponent.MoveValue.Equals(Vector2.zero))
            {
                Character.StateMachine.SwitchState(new PlayerMoveState(Character));
                return;
            }

            Move(Vector3.zero, deltaTime);
        }

        private void OnJump()
        {
            Character.StateMachine.SwitchState(new PlayerJumpState(Character));
        }

        public override void Exit()
        {
            Character.InputComponent.JumpEvent -= OnJump;
        }
    }
}