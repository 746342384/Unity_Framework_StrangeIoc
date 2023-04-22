using UnityEngine;

namespace Battle.Character.Player.State
{
    public class PlayerRollForwardState : PlayerStateBase
    {
        public PlayerRollForwardState(PlayerBase character) : base(character)
        {
        }

        public override void Enter()
        {
            Debug.Log("PlayerRollForwardState");
            AddForce = Character.CharacterData.RollForwardAddForce;
            Character.Animator.CrossFadeInFixedTime("RollForward", 0.1f);
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