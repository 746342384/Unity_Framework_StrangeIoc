using System.Collections.Generic;
using Battle.Character.Base.Component;
using Battle.Character.Player;
using Battle.Character.Player.State;
using Battle.Character.Weapon;
using Battle.Enemy;
using Battle.Enemy.State;
using UnityEngine;

namespace Battle.Character.Base
{
    [RequireComponent(typeof(EffectComponent))]
    [RequireComponent(typeof(StateMachineComponent))]
    [RequireComponent(typeof(CharacterController))]
    [RequireComponent(typeof(AttributeComponent))]
    public class CharacterBase : MonoBehaviour
    {
        public CharacterData CharacterData;
        public StateMachineComponent StateMachine { get; private set; }
        public CharacterController CharacterController { get; private set; }
        public AttributeComponent AttributeComponent;
        public EffectComponent EffectComponent { get; private set; }
        public Animator Animator;
        public WeaponBase WeaponBase;
        public CharacterType CharacterType;
        public List<Collider> Collider;
        public bool IsDead { get; set; }

        private void Awake()
        {
            CharacterController = GetComponent<CharacterController>();
            EffectComponent = GetComponent<EffectComponent>();
            StateMachine = GetComponent<StateMachineComponent>();
            Collider = TransformDeepFind.FindDeepComponents<Collider>(transform);
            OnAwake();
        }

        protected virtual void OnAwake()
        {
        }

        private void Start()
        {
            WeaponBase.Init(this);
            AttributeComponent = new AttributeComponent();
            AttributeComponent.Init(CharacterData);
            OnStart();
        }

        protected virtual void OnStart()
        {
        }

        public void SingleTakeDamage(CharacterBase origin, int attackDataIndex, Vector3 raycastHitPoint)
        {
            if (IsDead) return;
            AttributeComponent.Hp -= origin.CharacterData.AttackDatas[attackDataIndex].AtkValue;
            EffectComponent.PlayerAttackEfxByPos(CharacterData.HittedEfx, 2f, EffectParent.Middle, raycastHitPoint);
            if (AttributeComponent.Hp <= 0)
            {
                SetIsDead(true);
                AttributeComponent.Hp = 0;
                Dead();
            }

            OnSingleTakeDamage(origin, attackDataIndex, raycastHitPoint);
        }

        protected virtual void OnSingleTakeDamage(CharacterBase origin, int attackDataIndex, Vector3 raycastHitPoint)
        {
        }

        private void Dead()
        {
            DisableAllCollider();
            switch (CharacterType)
            {
                case CharacterType.Player:
                    StateMachine.SwitchState(new PlayerDeadState(this as PlayerBase));
                    break;
                case CharacterType.Enemy:
                    StateMachine.SwitchState(new EnemyDeadState(this as EnemyBase));
                    break;
            }
        }

        private void DisableAllCollider()
        {
            foreach (var collider1 in Collider)
            {
                collider1.enabled = false;
            }
        }

        protected void EnbleAllCollider()
        {
            foreach (var collider1 in Collider)
            {
                collider1.enabled = true;
            }
        }

        protected void SetIsDead(bool isDead)
        {
            IsDead = isDead;
        }
    }
}