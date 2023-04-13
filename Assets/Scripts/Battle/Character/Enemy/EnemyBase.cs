using Battle.AI.Const;
using Battle.Character.Base;
using Battle.Character.Base.Component;
using UnityEngine;

namespace Battle.Enemy
{
    [RequireComponent(typeof(StateMachineComponent))]
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(CharacterController))]
    [RequireComponent(typeof(MoveComponent))]
    public class EnemyBase : CharacterBase
    {
        public AIType Type; //敌人类型
    }
}