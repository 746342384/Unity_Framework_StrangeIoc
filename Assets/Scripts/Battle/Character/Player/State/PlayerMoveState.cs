using Battle.Character.Base;
using UnityEngine;

namespace Battle.Character.Player.State
{
    public class PlayerMoveState : PlayerStateBase
    {
        public PlayerMoveState(CharacterBase character) : base(character)
        {
        }

        public override void Enter()
        {
        }

        public override void Tick(float deltaTime)
        {
            var vector2 = new Vector2(Character.InputComponent.HorizontalInput, Character.InputComponent.VerticalInput);

            if (vector2 is { x: > 0, y: > 0 })
            {
                Character.Animator.Play("RunLeft");
            }
            else if (vector2 is { x: > 0, y: < 0 })
            {
                Character.Animator.Play("RunBackwardLeft");
            }
            else if (vector2 is { x: < 0, y: < 0 })
            {
                Character.Animator.Play("RunBackwardRight");
            }
            else if (vector2 is { x: < 0, y: > 0 })
            {
                Character.Animator.Play("RunRight");
            }
            else if (vector2.x > 0)
            {
                Character.Animator.Play("RunLeft");
            }
            else if (vector2.x < 0)
            {
                Character.Animator.Play("RunRight");
            }
            else if (vector2.y > 0)
            {
                Character.Animator.Play("RunForward");
            }
            else if (vector2.y < 0)
            {
                Character.Animator.Play("RunBackward");
            }


            var movement = CalculateMovement(vector2);
            Move(movement * Character.CharacterData.MoveSpeed, deltaTime);
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

        public override void Exit()
        {
        }
    }
}