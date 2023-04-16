using System;
using Battle.Character.Base;
using Battle.Character.Base.Component;
using Framework.framework.sound;

namespace Battle.Character.Player.State
{
    public abstract class PlayerStateBase : StateBase
    {
        protected readonly CharacterBase Character;
        protected bool IsApplyForce;
        protected float AddForce;
        private readonly ISoundManager _soundManager;

        protected PlayerStateBase(CharacterBase character)
        {
            Character = character;
            _soundManager = GameContext.Instance.GetComponent<ISoundManager>() as ISoundManager;
        }

        protected void ApplyForce(float attackDataAddForce)
        {
            if (!IsApplyForce)
            {
                Character.MoveComponent.AddForce(Character.transform.forward.normalized * attackDataAddForce);
                IsApplyForce = true;
            }
        }

        protected void PlayAttackSfx(float normalizedTime, AttackData attackData)
        {
            if (Math.Abs(normalizedTime - attackData.AttackSfxTime) < 0.01f)
            {
                _soundManager?.PlaySfx(attackData.AttackSfx);
            }
        }

        protected void ExecuteAttact(float normalizedTime, AttackData attackData)
        {
            if (normalizedTime > attackData.AttackStart)
            {
                Character.WeaponBase.StartAttack();
            }

            if (normalizedTime >= attackData.AttackEnd)
            {
                Character.WeaponBase.EndAttack();
            }
        }
    }
}