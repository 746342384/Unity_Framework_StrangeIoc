using Battle.Character.Base.Component;
using UnityEngine;

namespace Battle.Enemy.State
{
    public abstract class EnemyStateBase : StateBase
    {
        protected readonly EnemyBase EnemyBase;

        public EnemyStateBase(EnemyBase enemyBase)
        {
            EnemyBase = enemyBase;
        }

        public float GetDistance(Vector3 target)
        {
            return Vector3.Distance(EnemyBase.transform.position, target);
        }

        protected bool HasTarget()
        {
            return EnemyBase.Target != null;
        }
    }
}