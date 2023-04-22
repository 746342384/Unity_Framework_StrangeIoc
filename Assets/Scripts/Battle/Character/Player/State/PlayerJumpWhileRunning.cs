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
            AddForce = Character.CharacterData.RunningJumpAddForce;
            if (Character.InputComponent.IsMoveForward || Character.InputComponent.IsMoveBaclward) AddForce *= 1f;
            else AddForce = 0f;
            Character.Animator.CrossFadeInFixedTime("Jump", 0.1f);
        }

        public override void Tick(float deltaTime)
        {
            if (!IsApplyForce)
            {
                Character.MoveComponent.AddForce(Character.transform.forward.normalized * AddForce);
                IsApplyForce = true;
            }

            Character.MoveComponent.Move(Vector3.zero, deltaTime);
            var normalizedTime = GetNormalizedTime(Character.Animator);
            if (normalizedTime > _previousFrameTime && normalizedTime >= 0.8f)
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