using Battle.Character.Base;

namespace Battle.Enemy.State
{
    public class EnemyGetHitState : EnemyStateBase
    {
        public EnemyGetHitState(CharacterBase characterBase) : base(characterBase)
        {
        }

        public override void Enter()
        {
            CharacterBase.Animator.CrossFadeInFixedTime("GetHit", 0.2f);
        }

        public override void Tick(float deltaTime)
        {
            var n = GetNormalizedTime(CharacterBase.Animator);
            if (n >= 1f)
            {
                CharacterBase.StateMachine.SwitchState(new EnemyIdleState(CharacterBase));
                return;
            }
        }

        public override void Exit()
        {
        }
    }
}