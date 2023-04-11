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

        private void Awake()
        {
            OnAwake();
        }

        protected virtual void OnAwake()
        {
        }

        private void Start()
        {
            OnStart();
        }

        protected virtual void OnStart()
        {
        }

        public void Init(CharacterData characterData)
        {
            CharacterData = characterData;
        }

        private float drag = 0.3f;
        private float verticalVelocity;
        private Vector3 impact;
        private Vector3 dampingVelocity;
        public Vector3 MoveMent => impact + Vector3.up * verticalVelocity;

        private void Update()
        {
            if (verticalVelocity < 0 && CharacterController.isGrounded)
            {
                verticalVelocity = Physics.gravity.y * Time.deltaTime;
            }
            else
            {
                verticalVelocity += Physics.gravity.y * Time.deltaTime;
            }

            impact = Vector3.SmoothDamp(impact, Vector3.zero, ref dampingVelocity, drag);
            if (impact.sqrMagnitude < 0.2f * 0.2f)
            {
                impact = Vector3.zero;
            }
        }
    }
}