using Battle.Character.Base;
using UnityEngine;

namespace Battle.Character.Player.State
{
    public class PlayerMoveState : PlayerStateBase
    {
        private const float FixedTransitionDuration = 0.1f;
        private string StateName;
        private static readonly int V = Animator.StringToHash("V");
        private static readonly int H = Animator.StringToHash("H");

        public PlayerMoveState(CharacterBase character) : base(character)
        {
        }

        public override void Enter()
        {
            Character.Animator.CrossFadeInFixedTime("Run", FixedTransitionDuration);
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
                Character.StateMachine.SwitchState(new PlayerJumpWhileRunning(Character));
                return;
            }


            if (Character.InputComponent.HorizontalInput == 0 && Character.InputComponent.VerticalInput == 0)
            {
                Character.StateMachine.SwitchState(new PlayerIdleState(Character));
                return;
            }

            var vector2 = GetMovement();
            var H = Mathf.Clamp(Character.InputComponent.HorizontalInput, -1, 1);
            var V = Mathf.Clamp(Character.InputComponent.VerticalInput, -1, 1);
            Character.Animator.SetFloat(PlayerMoveState.V, V, 0.1f, deltaTime);
            Character.Animator.SetFloat(PlayerMoveState.H, H, 0.1f, deltaTime);
            var movement = CalculateMovement(vector2);
            Move(movement * Character.CharacterData.MoveSpeed, deltaTime);
            if (vector2.x != 0)
            {
                FaceMovementDirection(movement, deltaTime);
            }
        }

        public override void Exit()
        {
        }
    }
}