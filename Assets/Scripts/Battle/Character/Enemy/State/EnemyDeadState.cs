
namespace Battle.Enemy.State
{
    public class EnemyDeadState : EnemyStateBase
    {

        public EnemyDeadState(EnemyBase enemyBase) : base(enemyBase)
        {
        }

        public override void Enter()
        {
            EnemyBase.Animator.CrossFadeInFixedTime("Dead", 0.2f);
        }

        public override void Tick(float deltaTime)
        {
        }

        public override void Exit()
        {
        }
    }
}