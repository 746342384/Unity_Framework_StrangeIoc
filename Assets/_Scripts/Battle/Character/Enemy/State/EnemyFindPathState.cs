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
            if (!HasTarget() || GetDistance(EnemyBase.Target.transform.position) >
                EnemyBase.CharacterData.FindPathDistance ||
                EnemyBase.Target.IsDead)
            {
                EnemyBase.StateMachine.SwitchState(new EnemyIdleState(EnemyBase));
                return;
            }

            if (GetDistance(EnemyBase.Target.transform.position) < EnemyBase.CharacterData.AttackDistance)
            {
                EnemyBase.StateMachine.SwitchState(new EnemyAttackingState(EnemyBase, 0));
                return;
            }

            EnemyBase.AIMoveComponent.MoveToTarget(deltaTime);
        }

        public override void Exit()
        {
        }
    }
}