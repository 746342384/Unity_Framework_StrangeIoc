using System.Collections.Generic;
using Battle.Character.Base.Component;
using Battle.Character.Controller;
using Battle.Character.Weapon;
using Cysharp.Threading.Tasks;
using Extensions;
using UnityEngine;

namespace Battle.Character.Base
{
    [RequireComponent(typeof(EffectComponent))]
    [RequireComponent(typeof(StateMachineComponent))]
    [RequireComponent(typeof(CharacterController))]
    [RequireComponent(typeof(AttributeComponent))]
    [RequireComponent(typeof(ReceiveForceComponent))]
    public class CharacterBase : MonoBehaviour
    {
        public ReceiveForceComponent ReceiveForceComponent { get; private set; }
        public StateMachineComponent StateMachine { get; private set; }
        public CharacterController CharacterController { get; private set; }
        public AttributeComponent AttributeComponent;
        public EffectComponent EffectComponent { get; private set; }
        public CharacterData CharacterData;
        public WeaponBase WeaponBase { get; private set; }
        public Animator Animator { get; private set; }
        private Transform Root { set; get; }
        public List<Collider> Collider;
        
        public CharacterType CharacterType;
        public bool IsDead { get; private set; }

        private void Awake()
        {
            CharacterController = GetComponent<CharacterController>();
            EffectComponent = GetComponent<EffectComponent>();
            StateMachine = GetComponent<StateMachineComponent>();
            ReceiveForceComponent = GetComponent<ReceiveForceComponent>();
            Collider = TransformDeepFind.FindDeepComponents<Collider>(transform);
            OnAwake();
        }

        protected virtual void OnAwake()
        {
        }

        public async void Init(string path)
        {
            await LoadModel(path);
            InitAttribute();
            InitAnimator();
            InitReciveForce();
            InitWeapon();
            OnInit();
        }

        private async UniTask LoadModel(string path)
        {
            var obj = await BattleController.Ins.LoadModel(path);
            obj.SetParent(transform);
            obj.SetScale(Vector3.one);
            obj.SetLocalPostion(Vector3.zero);
            Root = obj.transform;
        }

        private void InitAttribute()
        {
            AttributeComponent = new AttributeComponent();
            AttributeComponent.Init(CharacterData);
        }

        private void InitAnimator()
        {
            Animator = Root != null ? Root.GetComponent<Animator>() : null;
        }

        private void InitReciveForce()
        {
            ReceiveForceComponent.Init(this);
        }

        private void InitWeapon()
        {
            WeaponBase = TransformDeepFind.FindDeepComponent<WeaponBase>(transform);
            if (WeaponBase != null) WeaponBase.Init(this);
        }

        protected virtual void OnInit()
        {
        }

        private void Update()
        {
            OnUpdate();
        }

        protected virtual void OnUpdate()
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
            OnDead();
        }

        protected virtual void OnDead()
        {
            
        }

        private void DisableAllCollider()
        {
            foreach (var collider1 in Collider)
            {
                collider1.enabled = false;
            }
        }

        private void EnbleAllCollider()
        {
            foreach (var collider1 in Collider)
            {
                collider1.enabled = true;
            }
        }

        private void SetIsDead(bool isDead)
        {
            IsDead = isDead;
        }

        public void Reborn()
        {
            AttributeComponent.Hp = AttributeComponent.MaxHp;
            EnbleAllCollider();
            SetIsDead(false);
            OnReborn();
        }

        protected virtual void OnReborn()
        {
        }
    }
}