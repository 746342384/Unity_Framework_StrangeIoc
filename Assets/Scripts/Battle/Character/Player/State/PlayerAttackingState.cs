using System;
using Battle.Character.Base;
using Framework.framework.sound;
using UnityEngine;

namespace Battle.Character.Player.State
{
    public class PlayerAttackingState : PlayerStateBase
    {
        private int _index;
        private AttackData _attackData;
        private ISoundManager _soundManager;

        public PlayerAttackingState(CharacterBase character, int index) : base(character)
        {
            character.AttackIndex = index;
            _index = index;
            Debug.Log(index);
        }

        public override void Enter()
        {
            _attackData = Character.CharacterData.AttackDatas[_index];
            _soundManager = GameContext.Instance.GetComponent<ISoundManager>() as ISoundManager;
            Character.Animator.CrossFadeInFixedTime(_attackData.AnimationName, 0.1f);
        }

        public override void Tick(float deltaTime)
        {
            Character.MoveComponent.Move(Vector3.zero, deltaTime);

            if (!IsApplyForce)
            {
                Character.MoveComponent.AddForce(Character.transform.forward.normalized * _attackData.AddForce);
                IsApplyForce = true;
            }

            var normalizedTime = GetNormalizedTime(Character.Animator);

            if (Math.Abs(normalizedTime - _attackData.AttackSfxTime) < 0.01f)
            {
                _soundManager?.PlaySfx(_attackData.AttackSfx);
            }

            if (normalizedTime > _attackData.AttackStart)
            {
                Character.WeaponBase.EnableCollider();
            }

            if (normalizedTime >= _attackData.AttackEnd)
            {
                Character.WeaponBase.DisableCollider();
            }

            if (normalizedTime > 0.5f && Character.InputComponent.CancelAttacking)
            {
                Character.StateMachine.SwitchState(new PlayerJumpState(Character));
                return;
            }

            if (normalizedTime >= 1f)
            {
                Character.StateMachine.SwitchState(new PlayerIdleState(Character));
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
                return;
            }
        }

        public override void Exit()
        {
        }
    }
}