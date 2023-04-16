using System.Collections.Generic;
using Battle.Character.Base.Component;
using Battle.Character.Player.Weapon;
using Battle.Enemy.State;
using UnityEngine;

namespace Battle.Character.Base
{
    public class CharacterBase : MonoBehaviour
    {
        public CharacterData CharacterData;
        public InputComponent InputComponent { get; private set; }
        public StateMachineComponent StateMachine { get; private set; }
        public Animator Animator { get; private set; }
        public CharacterController CharacterController { get; private set; }
        public WeaponBase WeaponBase;
        public MoveComponent MoveComponent { get; private set; }
        public AttributeComponent AttributeComponent;
        public CharacterType CharacterType;
        public List<Collider> Collider;
        public bool IsDead { get; private set; }

        private void Awake()
        {
            StateMachine = GetComponent<StateMachineComponent>();
            Animator = GetComponent<Animator>();
            CharacterController = GetComponent<CharacterController>();
            MoveComponent = GetComponent<MoveComponent>();
            InputComponent = GetComponent<InputComponent>();
            Collider = TransformDeepFind.FindDeepComponents<Collider>(transform);
            OnAwake();
        }

        protected virtual void OnAwake()
        {
        }

        private void Start()
        {
            MoveComponent.Init(this);
            WeaponBase.Init(this);
            AttributeComponent = new AttributeComponent();
            AttributeComponent.Init(CharacterData);
            OnStart();
        }

        protected virtual void OnStart()
        {
        }

        public void SingleTakeDamage(CharacterBase origin, int attackDataIndex)
        {
            if (IsDead) return;
            AttributeComponent.Hp -= origin.CharacterData.AttackDatas[attackDataIndex].AtkValue;
            if (AttributeComponent.Hp <= 0)
            {
                SetIsDead(true);
                AttributeComponent.Hp = 0;
                Dead();
            }
        }

        private void Dead()
        {
            DisableAllCollider();
            switch (CharacterType)
            {
                case CharacterType.Player:
                    break;
                case CharacterType.Enemy:
                    StateMachine.SwitchState(new EnemyDeadState(this));
                    break;
            }
        }

        protected void DisableAllCollider()
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

        public void SetIsDead(bool isDead)
        {
            IsDead = isDead;
        }
    }
}