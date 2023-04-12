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

        private bool isJump;
        private bool isRolling;

        public PlayerMoveState(CharacterBase character) : base(character)
        {
        }

        public override void Enter()
        {
            Debug.Log("PlayerMoveState");
            Character.InputComponent.JumpEvent += OnJump;
            Character.InputComponent.RollForwardEvent += OnRollForward;
            Character.InputComponent.RollBackwardEvent += OnRollBackward;
            Character.InputComponent.RollLeftEvent += OnRollLeft;
            Character.InputComponent.RollRightEvent += OnRollRight;
            Character.Animator.CrossFadeInFixedTime("Run", FixedTransitionDuration);
        }

        public override void Tick(float deltaTime)
        {
            if (isRolling || isJump)
            {
                return;
            }

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

            if (Character.InputComponent.MoveValue == Vector2.zero)
            {
                Character.StateMachine.SwitchState(new PlayerIdleState(Character));
                return;
            }

            var vector2 = Character.MoveComponent.GetMovement();
            var x = Mathf.Clamp(vector2.x, -1, 1);
            var y = Mathf.Clamp(vector2.y, -1, 1);
            Character.Animator.SetFloat(H, x, 0.1f, deltaTime);
            Character.Animator.SetFloat(V, y, 0.1f, deltaTime);
            var movement = Character.MoveComponent.CalculateMovement(vector2);
            Character.MoveComponent.Move(movement * Character.CharacterData.MoveSpeed, deltaTime);
            if (vector2.x != 0)
            {
                Character.MoveComponent.FaceMovementDirection(movement, deltaTime);
            }
        }

        private void OnRollForward()
        {
            isRolling = true;
            Character.StateMachine.SwitchState(new PlayerRollForwardState(Character));
        }

        private void OnRollBackward()
        {
            isRolling = true;
            Character.StateMachine.SwitchState(new PlayerRollBackwardState(Character));
        }

        private void OnRollRight()
        {
            isRolling = true;
            Character.StateMachine.SwitchState(new PlayerRollRightState(Character));
        }

        private void OnRollLeft()
        {
            isRolling = true;
            Character.StateMachine.SwitchState(new PlayerRollLeftState(Character));
        }

        private void OnJump()
        {
            isJump = true;
            Character.StateMachine.SwitchState(new PlayerJumpWhileRunning(Character));
        }

        public override void Exit()
        {
            isRolling = false;
            isJump = false;
            Character.InputComponent.JumpEvent -= OnJump;
            Character.InputComponent.RollForwardEvent -= OnRollForward;
            Character.InputComponent.RollBackwardEvent -= OnRollBackward;
            Character.InputComponent.RollLeftEvent -= OnRollLeft;
            Character.InputComponent.RollRightEvent -= OnRollRight;
        }
    }
}