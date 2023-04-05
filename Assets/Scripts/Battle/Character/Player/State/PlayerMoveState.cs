using Battle.Character.Base;
using UnityEngine;

namespace Battle.Character.Player.State
{
    public class PlayerMoveState : PlayerStateBase
    {
        private const float FixedTransitionDuration = 0.1f;
        private string StateName;

        public PlayerMoveState(CharacterBase character) : base(character)
        {
        }

        public override void Enter()
        {
            Character.Animator.CrossFadeInFixedTime("Run", FixedTransitionDuration);
        }

        public override void Tick(float deltaTime)
        {
            if (Character.InputComponent.HorizontalInput == 0 && Character.InputComponent.VerticalInput == 0)
            {
                Character.StateMachine.SwitchState(new PlayerIdleState(Character));
                return;
            }

            var vector2 = new Vector2(Character.InputComponent.HorizontalInput, Character.InputComponent.VerticalInput);
            var H = Mathf.Clamp(Character.InputComponent.HorizontalInput, -1, 1);
            var V = Mathf.Clamp(Character.InputComponent.VerticalInput, -1, 1);
            Character.Animator.SetFloat("V", V, 0.1f, deltaTime);
            Character.Animator.SetFloat("H", H, 0.1f, deltaTime);
            var movement = CalculateMovement(vector2);
            Move(movement * Character.CharacterData.MoveSpeed, deltaTime);
            if (vector2.x != 0)
            {
                FaceMovementDirection(movement, deltaTime);
            }
        }

        private Vector3 CalculateMovement(Vector2 vector2)
        {
            var transform1 = Character.transform;
            var forward = transform1.forward;
            var right = transform1.right;
            forward.y = 0;
            right.y = 0;
            forward.Normalize();
            right.Normalize();
            return forward * vector2.y + right * vector2.x;
        }

        private void FaceMovementDirection(Vector3 movement, float deltaTime)
        {
            Character.transform.rotation = Quaternion.Lerp(Character.transform.rotation,
                Quaternion.LookRotation(movement), deltaTime * Character.CharacterData.RotationDamping);
        }

        public override void Exit()
        {
        }
    }
}