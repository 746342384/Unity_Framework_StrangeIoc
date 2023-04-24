
namespace Battle.Enemy.State
{
    public class EnemyGetHitState : EnemyStateBase
    {
        public EnemyGetHitState(EnemyBase enemyBase) : base(enemyBase)
        {
        }

        public override void Enter()
        {
            EnemyBase.Animator.CrossFadeInFixedTime(EnemyBase.CharacterData.GetHitAnimationName, 0.2f);
        }

        public override void Tick(float deltaTime)
        {
            var n = GetNormalizedTime(EnemyBase.Animator);
            if (n >= 1f)
            {
                EnemyBase.StateMachine.SwitchState(new EnemyIdleState(EnemyBase));
                return;
            }
        }

        public override void Exit()
        {
        }
    }
}