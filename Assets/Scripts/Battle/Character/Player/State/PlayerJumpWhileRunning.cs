using Battle.Character.Base;
using UnityEngine;

namespace Battle.Character.Player.State
{
    public class PlayerJumpWhileRunning : PlayerStateBase
    {
        private float _previousFrameTime;

        public PlayerJumpWhileRunning(CharacterBase character) : base(character)
        {
        }

        public override void Enter()
        {
            Debug.Log("PlayerJumpWhileRunning");
            var movement = Character.MoveComponent.GetMovement();
            AddForce = Character.CharacterData.RunningJumpAddForce;
            if (movement.y > 0)
            {
                AddForce *= 1f;
            }
            else
            {
                AddForce *= -1f;
            }

            Character.Animator.CrossFadeInFixedTime("JumpWhileRunning", 0.1f);
        }

        public override void Tick(float deltaTime)
        {
            Character.MoveComponent.Move(Vector3.zero, deltaTime);
            if (!IsApplyForce)
            {
                Character.MoveComponent.AddForce(Character.transform.forward.normalized * AddForce);
                IsApplyForce = true;
            }

            var normalizedTime = GetNormalizedTime(Character.Animator);
            if (normalizedTime > _previousFrameTime && normalizedTime >= 1f)
            {
                Character.StateMachine.SwitchState(new PlayerMoveState(Character));
                return;
            }

            _previousFrameTime = normalizedTime;
        }

        public override void Exit()
        {
        }
    }
}