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
            Character.Animator.CrossFadeInFixedTime("Idle", FixedTransitionDuration);
        }

        private bool IsJumping { get; set; }

        public override void Tick(float deltaTime)
        {
            if (IsJumping)
            {
                var normalizedTime = GetNormalizedTime(Character.Animator);
                if (normalizedTime >= 1)
                {
                    IsJumping = false;
                }

                return;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (IsJumping) return;
                IsJumping = true;
                Character.StateMachine.SwitchState(new PlayerJumpState(Character));
                return;
            }


            if (Character.InputComponent.HorizontalInput != 0 || Character.InputComponent.VerticalInput != 0)
            {
                Character.StateMachine.SwitchState(new PlayerMoveState(Character));
                return;
            }

            Move(Vector3.zero, deltaTime);
        }

        public override void Exit()
        {
        }
    }
}