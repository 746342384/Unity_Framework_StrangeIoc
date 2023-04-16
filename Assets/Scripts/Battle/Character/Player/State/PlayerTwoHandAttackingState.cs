using Battle.Character.Base;
using UnityEngine;

namespace Battle.Character.Player.State
{
    public class PlayerTwoHandAttackingState : PlayerStateBase
    {
        private AttackData _attackData;

        public PlayerTwoHandAttackingState(CharacterBase character) : base(character)
        {
        }

        public override void Enter()
        {
            _attackData = Character.CharacterData.AttackDatas[0];
            Character.Animator.CrossFadeInFixedTime(_attackData.AnimationName, 0.1f);
        }

        public override void Tick(float deltaTime)
        {
            Character.MoveComponent.Move(Vector3.zero, deltaTime);
            ApplyForce(_attackData.AddForce);
            
            var normalizedTime = GetNormalizedTime(Character.Animator);
            
            PlayAttackSfx(normalizedTime, _attackData);
            ExecuteAttact(normalizedTime, _attackData);

            if (normalizedTime >= 1f)
            {
                Character.StateMachine.SwitchState(new PlayerIdleState(Character));
            }
        }


        public override void Exit()
        {
        }
    }
}