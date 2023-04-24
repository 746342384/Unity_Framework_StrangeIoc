using System;
using Battle.AI.Const;
using Battle.Character.Base;
using Battle.Character.Base.Component;
using Battle.Character.Controller;
using Battle.Enemy.State;
using UnityEngine;

namespace Battle.Enemy
{
    [RequireComponent(typeof(AIMoveComponent))]
    public class EnemyBase : CharacterBase
    {
        public AIType Type; //敌人类型
        public AIMoveComponent AIMoveComponent;
        public CharacterBase Target;

        protected override void OnAwake()
        {
            AIMoveComponent = GetComponent<AIMoveComponent>();
            base.OnAwake();
        }

        protected override void OnInit()
        {
            base.OnInit();
            AIMoveComponent.Init(this);
            CharacterType = CharacterType.Enemy;
            StateMachine.SwitchState(new EnemyIdleState(this));
        }

        protected override void OnDead()
        {
            base.OnDead();
            StateMachine.SwitchState(new EnemyDeadState(this));
        }

        protected override void OnReborn()
        {
            base.OnReborn();
            StateMachine.SwitchState(new EnemyIdleState(this));
        }

        protected override void OnSingleTakeDamage(CharacterBase origin, int attackDataIndex, Vector3 raycastHitPoint)
        {
            base.OnSingleTakeDamage(origin, attackDataIndex, raycastHitPoint);
            if (!IsDead)
            {
                StateMachine.SwitchState(new EnemyGetHitState(this));
            }
        }

        protected override void OnUpdate()
        {
            Target = BattleController.Ins.FindNearTarget(this);
        }
    }
}