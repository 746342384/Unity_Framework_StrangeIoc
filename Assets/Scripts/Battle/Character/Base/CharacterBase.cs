using Battle.Character.Base.Component;
using Battle.Character.Player.Weapon;
using UnityEngine;

namespace Battle.Character.Base
{
    public class CharacterBase : MonoBehaviour
    {
        public CharacterData CharacterData;
        public InputComponent InputComponent;
        public StateMachineComponent StateMachine;
        public Animator Animator;
        public CharacterController CharacterController;
        public WeaponBase WeaponBase;
        public MoveComponent MoveComponent;

        private void Awake()
        {
            OnAwake();
        }

        protected virtual void OnAwake()
        {
        }

        private void Start()
        {
            MoveComponent.Init(this);
            OnStart();
        }

        protected virtual void OnStart()
        {
        }
    }
}