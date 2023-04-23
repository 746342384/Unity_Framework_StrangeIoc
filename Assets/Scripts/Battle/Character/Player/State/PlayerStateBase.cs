using System;
using Battle.Character.Base.Component;
using Framework.framework.sound;

namespace Battle.Character.Player.State
{
    public abstract class PlayerStateBase : StateBase
    {
        private readonly ISoundManager _soundManager;
        protected readonly PlayerBase Character;
        protected bool IsApplyForce;
        protected float AddForce;

        protected PlayerStateBase(PlayerBase character)
        {
            Character = character;
            _soundManager = GameContext.Instance.GetComponent<ISoundManager>() as ISoundManager;
        }

        protected void ApplyForce(float attackDataAddForce)
        {
            if (IsApplyForce) return;
            Character.ReceiveForceComponent.AddForce(Character.transform.forward.normalized * attackDataAddForce);
            IsApplyForce = true;
        }

        protected void PlayAttackSfx(float normalizedTime, AttackData attackData)
        {
            if (Math.Abs(normalizedTime - attackData.AttackSfxTime) < 0.01f)
            {
                _soundManager?.PlaySfx(attackData.AttackSfx);
            }
        }

        protected void PlayAttackEfx(float normalizedTime, AttackData attackData)
        {
            if (Math.Abs(normalizedTime - attackData.AttackEfxTime) < 0.01f)
            {
                Character.EffectComponent.PlayerAttackEfx(attackData.AttackEfx, attackData.AttackEfxDuration,attackData.EffectParent);
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