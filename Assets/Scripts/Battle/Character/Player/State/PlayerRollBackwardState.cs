using UnityEngine;

namespace Battle.Character.Player.State
{
    public class PlayerRollBackwardState : PlayerStateBase
    {
        public PlayerRollBackwardState(PlayerBase character) : base(character)
        {
        }

        public override void Enter()
        {
            Debug.Log("PlayerRollBackwardState");
            AddForce = Character.CharacterData.RollBackwardAddForce * -1f;
            Character.Animator.CrossFadeInFixedTime("RollBackward", 0.1f);
        }

        public override void Tick(float deltaTime)
        {
            Character.MoveComponent.Move(Vector3.zero, deltaTime);
            if (!IsApplyForce)
            {
                Character.ReceiveForceComponent.AddForce(Character.transform.forward.normalized * AddForce);
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