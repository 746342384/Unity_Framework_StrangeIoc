using Battle.Character.Base;
using UnityEngine;

namespace Battle.Character.Player.State
{
    public class PlayerJumpState : PlayerStateBase
    {
        public PlayerJumpState(CharacterBase character) : base(character)
        {
        }

        public override void Enter()
        {
            Debug.Log("PlayerJumpState");
            Character.Animator.CrossFadeInFixedTime("Jump", 0.1f);
        }

        public override void Tick(float deltaTime)
        {
            Character.MoveComponent.Move(Vector3.zero, deltaTime);
            var normalizedTime = GetNormalizedTime(Character.Animator);
            if (normalizedTime >= 1f)
            {
                Character.StateMachine.SwitchState(new PlayerIdleState(Character));
                return;
            }
        }

        public override void Exit()
        {
        }
    }
}