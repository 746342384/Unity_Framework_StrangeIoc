using UnityEngine;

namespace Battle.Character.Player.State
{
    public class PlayerJumpState : PlayerStateBase
    {
        private float _previousFrameTime;

        public PlayerJumpState(PlayerBase character) : base(character)
        {
        }

        public override void Enter()
        {
            Debug.Log("PlayerJumpState");
            AddForce = Character.CharacterData.JumpAddForce;
            if (Character.InputComponent.IsMoveForward || Character.InputComponent.IsMoveBaclward)
                AddForce = Mathf.Abs(AddForce);
            else AddForce = 0f;
            Character.Animator.CrossFadeInFixedTime(Character.CharacterData.JumpAnimationName,
                Character.CharacterData.JumpFixedTransitionDuration);
        }

        public override void Tick(float deltaTime)
        {
            Character.MoveComponent.Move(Vector3.zero, deltaTime);
            var normalizedTime = GetNormalizedTime(Character.Animator);

            if (normalizedTime >= Character.CharacterData.JumpAddForceStartTime && !IsApplyForce)
            {
                Character.MoveComponent.AddForce(Character.transform.forward.normalized * AddForce);
                IsApplyForce = true;
            }

            if (normalizedTime > _previousFrameTime && normalizedTime >= Character.CharacterData.JumpEndTime)
            {
                Character.StateMachine.SwitchState(new PlayerMoveState(Character));
                return;
            }

            _previousFrameTime = normalizedTime;
        }

        public override void Exit()
        {
            _previousFrameTime = 0;
        }
    }
}