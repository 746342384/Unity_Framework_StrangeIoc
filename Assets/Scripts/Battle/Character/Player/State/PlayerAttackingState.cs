using Battle.Character.Base;
using UnityEngine;

namespace Battle.Character.Player.State
{
    public class PlayerAttackingState : PlayerStateBase
    {
        private int _index;
        private AttackData _attackData;

        public PlayerAttackingState(CharacterBase character, int index) : base(character)
        {
            _index = index;
            character.WeaponBase.AttackDataIndex = index;
        }

        public override void Enter()
        {
            _attackData = Character.CharacterData.AttackDatas[_index];
            Character.Animator.CrossFadeInFixedTime(_attackData.AnimationName, 0.1f);
        }

        public override void Tick(float deltaTime)
        {
            Character.MoveComponent.Move(Vector3.zero, deltaTime);
            ApplyForce(_attackData.AddForce);

            var normalizedTime = GetNormalizedTime(Character.Animator);

            PlayAttackEfx(normalizedTime, _attackData);
            PlayAttackSfx(normalizedTime, _attackData);
            ExecuteAttact(normalizedTime, _attackData);

            if (normalizedTime > 0.5f && Character.InputComponent.CancelAttacking)
            {
                Character.StateMachine.SwitchState(new PlayerJumpState(Character));
                return;
            }

            if (normalizedTime >= 1f)
            {
                Character.StateMachine.SwitchState(new PlayerMoveState(Character));
                return;
            }

            if (normalizedTime >= _attackData.Time && Character.InputComponent.IsAttacking)
            {
                _index += 1;
                if (_index >= Character.CharacterData.AttackDatas.Count)
                {
                    return;
                }

                Character.StateMachine.SwitchState(new PlayerAttackingState(Character, _index));
            }
        }

        public override void Exit()
        {
        }
    }
}