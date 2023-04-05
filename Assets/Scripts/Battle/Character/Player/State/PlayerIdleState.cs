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

        public override void Tick(float deltaTime)
        {
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