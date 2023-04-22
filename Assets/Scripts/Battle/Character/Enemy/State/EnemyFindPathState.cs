namespace Battle.Enemy.State
{
    public class EnemyFindPathState : EnemyStateBase
    {
        public EnemyFindPathState(EnemyBase enemyBase) : base(enemyBase)
        {
        }

        public override void Enter()
        {
            EnemyBase.Animator.CrossFadeInFixedTime("Walk", 0.2f);
        }

        public override void Tick(float deltaTime)
        {
            if (GetDistance(EnemyBase.Target.transform.position) > EnemyBase.CharacterData.FindPathDistance)
            {
                EnemyBase.StateMachine.SwitchState(new EnemyIdleState(EnemyBase));
                return;
            }

            EnemyBase.AIMoveComponent.MoveToTarget(deltaTime);
        }

        public override void Exit()
        {
        }
    }
}