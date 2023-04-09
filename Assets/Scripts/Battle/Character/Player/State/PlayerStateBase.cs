using Battle.Character.Base;
using Battle.Character.Base.Component;
using UnityEngine;

namespace Battle.Character.Player.State
{
    public abstract class PlayerStateBase : StateBase
    {
        protected readonly CharacterBase Character;

        public PlayerStateBase(CharacterBase character)
        {
            Character = character;
        }

        protected void Move(Vector3 motion, float deltaTime)
        {
            var moveMent = Character.MoveMent;
            Character.CharacterController.Move((motion + moveMent) * deltaTime);
        }

        protected Vector3 CalculateMovement(Vector2 vector2)
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

        protected void FaceMovementDirection(Vector3 movement, float deltaTime)
        {
            Character.transform.rotation = Quaternion.Lerp(Character.transform.rotation,
                Quaternion.LookRotation(movement), deltaTime * Character.CharacterData.RotationDamping);
        }

        protected Vector2 GetMovement()
        {
            return Character.InputComponent.MoveValue;
        }
    }
}