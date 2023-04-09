using Battle.Character.Base;
using UnityEngine;

namespace Battle.Character.Player.State
{
    public class PlayerRollForwardState : PlayerStateBase
    {
        public PlayerRollForwardState(CharacterBase character) : base(character)
        {
        }

        public override void Enter()
        {
            Debug.Log("PlayerRollForwardState");
            SetMoveTarget(Character.CharacterData.RollForwardDistance);
            Character.Animator.CrossFadeInFixedTime("RollForward", 0.1f);
        }

        public override void Tick(float deltaTime)
        {
            var normalizedTime = GetNormalizedTime(Character.Animator);
            LerpMoveToTarget(normalizedTime);

            if (normalizedTime >= 0.8f)
            {
                Character.StateMachine.SwitchState(new PlayerMoveState(Character));
            }
        }

        public override void Exit()
        {
        }
    }
}