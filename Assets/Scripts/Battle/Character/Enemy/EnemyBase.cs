using Battle.AI.Const;
using Battle.Character.Base;
using Battle.Character.Base.Component;
using Battle.Enemy.State;
using UnityEngine;

namespace Battle.Enemy
{
    [RequireComponent(typeof(StateMachineComponent))]
    [RequireComponent(typeof(MoveComponent))]
    public class EnemyBase : CharacterBase
    {
        public AIType Type; //敌人类型

        protected override void OnStart()
        {
            base.OnStart();
            CharacterType = CharacterType.Enemy;
            StateMachine.SwitchState(new EnemyIdleState(this));
        }

        [ContextMenu("Reborn")]
        public void Reborn()
        {
            AttributeComponent.Hp = AttributeComponent.MaxHp;
            StateMachine.SwitchState(new EnemyIdleState(this));
            EnbleAllCollider();
            SetIsDead(false);
        }

        protected override void OnSingleTakeDamage(CharacterBase origin, int attackDataIndex, Vector3 raycastHitPoint)
        {
            base.OnSingleTakeDamage(origin, attackDataIndex, raycastHitPoint);
            if (!IsDead)
            {
                StateMachine.SwitchState(new EnemyGetHitState(this));
            }
        }
    }
}