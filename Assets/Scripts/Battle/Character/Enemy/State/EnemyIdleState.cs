using UnityEngine;

namespace Battle.Enemy.State
{
    public class EnemyIdleState : EnemyStateBase
    {
        public EnemyIdleState(EnemyBase enemyBase) : base(enemyBase)
        {
        }

        public override void Enter()
        {
            EnemyBase.Animator.CrossFadeInFixedTime("Idle", 0.2f);
        }

        public override void Tick(float deltaTime)
        {
            EnemyBase.AIMoveComponent.Move(Vector3.zero, deltaTime);
            if (GetDistance(EnemyBase.Target.transform.position) <= EnemyBase.CharacterData.FindPathDistance &&
                !EnemyBase.Target.IsDead)
            {
                EnemyBase.StateMachine.SwitchState(new EnemyFindPathState(EnemyBase));
                return;
            }
        }

        public override void Exit()
        {
        }
    }
}