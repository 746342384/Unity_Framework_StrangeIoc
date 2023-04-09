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
            Character.InputComponent.JumpEvent += OnJump;
            Character.InputComponent.RollForwardEvent += OnRollForward;
        }

        private bool isRollForward;
        private bool isJump;

        private void OnRollForward()
        {
            isRollForward = true;
            Character.StateMachine.SwitchState(new PlayerRollForwardState(Character));
        }

        private void OnJump()
        {
            isJump = true;
            Character.StateMachine.SwitchState(new PlayerJumpWhileRunning(Character));
        }

        public override void Tick(float deltaTime)
        {
            if (isRollForward || isJump)
            {
                return;
            }

            if (Character.InputComponent.MoveValue == Vector2.zero)
            {
                Character.StateMachine.SwitchState(new PlayerIdleState(Character));
                return;
            }

            var vector2 = GetMovement();
            var x = Mathf.Clamp(vector2.x, -1, 1);
            var y = Mathf.Clamp(vector2.y, -1, 1);
            Character.Animator.SetFloat(H, x, 0.1f, deltaTime);
            Character.Animator.SetFloat(V, y, 0.1f, deltaTime);
            var movement = CalculateMovement(vector2);
            Move(movement * Character.CharacterData.MoveSpeed, deltaTime);
            if (vector2.x != 0)
            {
                FaceMovementDirection(movement, deltaTime);
            }
        }

        public override void Exit()
        {
            isRollForward = false;
            isJump = false;
            Character.InputComponent.JumpEvent -= OnJump;
            Character.InputComponent.RollForwardEvent -= OnRollForward;
        }
    }
}