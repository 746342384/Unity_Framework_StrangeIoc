using Battle.Character;
using UnityEngine;

namespace Battle.Enemy.State
{
    public class EnemyAttackingState : EnemyStateBase
    {
        private readonly int _attackIndex;
        private AttackData _attackData;

        public EnemyAttackingState(EnemyBase enemyBase, int attackIndex) : base(enemyBase)
        {
            _attackIndex = attackIndex;
        }

        public override void Enter()
        {
            _attackData = EnemyBase.CharacterData.AttackDatas[_attackIndex];
            EnemyBase.WeaponBase.ClearTargets();
            EnemyBase.Animator.CrossFadeInFixedTime(_attackData.AnimationName, 0.1f);
        }

        public override void Tick(float deltaTime)
        {
            EnemyBase.AIMoveComponent.Move(Vector3.zero, deltaTime);
            if (GetDistance(EnemyBase.Target.transform.position) > EnemyBase.CharacterData.AttackDistance)
            {
                EnemyBase.StateMachine.SwitchState(new EnemyIdleState(EnemyBase));
                return;
            }

            var normalizedTime = GetNormalizedTime(EnemyBase.Animator);
            if (normalizedTime >= _attackData.AttackStart)
            {
                EnemyBase.WeaponBase.StartAttack();
            }

            if (normalizedTime >= _attackData.AttackEnd)
            {
                EnemyBase.WeaponBase.EndAttack();
            }

            if (EnemyBase.Target.IsDead)
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