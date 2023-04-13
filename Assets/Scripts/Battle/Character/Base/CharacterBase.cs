using Battle.Character.Base.Component;
using Battle.Character.Player.Weapon;
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
        public int AttackIndex { get; set; }

        private void Awake()
        {
            StateMachine = GetComponent<StateMachineComponent>();
            Animator = GetComponent<Animator>();
            CharacterController = GetComponent<CharacterController>();
            MoveComponent = GetComponent<MoveComponent>();
            InputComponent = GetComponent<InputComponent>();
            OnAwake();
        }

        protected virtual void OnAwake()
        {
        }

        private void Start()
        {
            MoveComponent.Init(this);
            WeaponBase.Init(this);
            OnStart();
        }

        protected virtual void OnStart()
        {
        }
    }
}