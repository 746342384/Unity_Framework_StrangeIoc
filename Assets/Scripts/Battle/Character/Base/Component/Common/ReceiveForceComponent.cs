using UnityEngine;
using UnityEngine.AI;

namespace Battle.Character.Base.Component
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class ReceiveForceComponent : MonoBehaviour
    {
        private CharacterBase _character;
        private NavMeshAgent Agent;
        private float _verticalVelocity;
        private Vector3 _dampingVelocity;
        private Vector3 _impact;
        public Vector3 MoveMent => _impact + Vector3.up * _verticalVelocity;

        public void Init(CharacterBase characterBase)
        {
            _character = characterBase;
        }

        private void Awake()
        {
            Agent = GetComponent<NavMeshAgent>();
        }

        private void FixedUpdate()
        {
            if (_character == null) return;
            if (_verticalVelocity < 0 && _character.CharacterController.isGrounded)
            {
                _verticalVelocity = Physics.gravity.y * Time.deltaTime;
            }
            else
            {
                _verticalVelocity += Physics.gravity.y * Time.deltaTime;
            }

            _impact = Vector3.SmoothDamp(_impact, Vector3.zero, ref _dampingVelocity,
                _character.CharacterData.MoveDrag);
            if (_impact.sqrMagnitude < 0.2f * 0.2f && Agent)
            {
                _impact = Vector3.zero;
                Agent.enabled = true;
            }
        }

        public void AddForce(Vector3 force)
        {
            _impact += force;
            if (Agent) Agent.enabled = false;
        }
    }
}