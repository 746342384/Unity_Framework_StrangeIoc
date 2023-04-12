using Battle.Character.Base;
using UnityEngine;

namespace Battle.Character.Player.State
{
    public class PlayerRollLeftState : PlayerStateBase
    {
        public PlayerRollLeftState(CharacterBase character) : base(character)
        {
        }

        public override void Enter()
        {
            Debug.Log("PlayerRollLeftState");
            AddForce = Character.CharacterData.RollLeftAddForce;
            Character.Animator.CrossFadeInFixedTime("RollLeft", 0.1f);
        }

        public override void Tick(float deltaTime)
        {
            Character.MoveComponent.Move(Vector3.zero, deltaTime);

            if (!IsApplyForce)
            {
                Character.MoveComponent.AddForce(Character.transform.right.normalized * -AddForce);
                IsApplyForce = true;
            }

            var normalizedTime = GetNormalizedTime(Character.Animator);
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