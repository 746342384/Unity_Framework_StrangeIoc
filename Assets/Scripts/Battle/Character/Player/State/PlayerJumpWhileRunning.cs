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
            var movement = GetMovement();
            var distance = Character.CharacterData.RunningJumpDistance;
            if (movement.y > 0)
            {
                distance *= 1f;
            }
            else
            {
                distance *= -1f;
            }

            SetMoveForwardTarget(distance);
            Character.Animator.CrossFadeInFixedTime("JumpWhileRunning", 0.1f);
        }

        public override void Tick(float deltaTime)
        {
            var normalizedTime = GetNormalizedTime(Character.Animator);
            LerpMoveToTarget(normalizedTime);


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