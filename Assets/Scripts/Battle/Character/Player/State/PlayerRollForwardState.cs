using Battle.Character.Base;
using UnityEngine;

namespace Battle.Character.Player.State
{
    public class PlayerRollForwardState : PlayerStateBase
    {
        private bool _isMoving;
        private Vector3 _targetPosition;
        private Vector3 _newPosition;
        private Vector3 _startPosition;


        public PlayerRollForwardState(CharacterBase character) : base(character)
        {
        }


        public override void Enter()
        {
            _isMoving = true;
            var transform = Character.transform;
            var position = transform.position;
            var forward = transform.forward;
            forward.y = 0.0f;
            forward.Normalize();
            _targetPosition = position + forward * Character.CharacterData.RollForwardDistance;
            _startPosition = position;
            Character.Animator.CrossFadeInFixedTime("RollForward", 0.1f);
        }

        public override void Tick(float deltaTime)
        {
            var normalizedTime = GetNormalizedTime(Character.Animator);
            if (_isMoving)
            {
                _newPosition = Vector3.Lerp(_startPosition, _targetPosition, normalizedTime);
                Character.transform.position = _newPosition;
            }

            if (normalizedTime >= 0.8f)
            {
                Character.StateMachine.SwitchState(new PlayerMoveState(Character));
                _isMoving = false;
            }
        }

        public override void Exit()
        {
        }
    }
}