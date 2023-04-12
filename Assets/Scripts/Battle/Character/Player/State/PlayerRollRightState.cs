using Battle.Character.Base;
using UnityEngine;

namespace Battle.Character.Player.State
{
    public class PlayerRollRightState : PlayerStateBase
    {
        public PlayerRollRightState(CharacterBase character) : base(character)
        {
        }

        public override void Enter()
        {
            Debug.Log("PlayerRollRightState");
            AddForce = Character.CharacterData.RollRightAddForce;
            Character.Animator.CrossFadeInFixedTime("RollRight", 0.1f);
        }

        public override void Tick(float deltaTime)
        {
            Character.MoveComponent.Move(Vector3.zero, deltaTime);
            var normalizedTime = GetNormalizedTime(Character.Animator);
            if (!IsApplyForce)
            {
                Character.MoveComponent.AddForce(Character.transform.right.normalized * AddForce);
                IsApplyForce = true;
            }

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