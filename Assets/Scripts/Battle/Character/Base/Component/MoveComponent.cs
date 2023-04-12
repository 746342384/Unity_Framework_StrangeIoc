using UnityEngine;
using UnityEngine.AI;

namespace Battle.Character.Base.Component
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class MoveComponent : MonoBehaviour
    {
        private CharacterBase _character;
        private Vector3 _targetPosition;
        private Vector3 _newPosition;
        private Vector3 _startPosition;
        private NavMeshAgent _agent;
        [SerializeField] private float _drag = 0.3f;
        private float verticalVelocity;
        private Vector3 dampingVelocity;
        private Vector3 impact;
        private Vector3 MoveMent => impact + Vector3.up * verticalVelocity;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
        }

        public void Init(CharacterBase characterBase)
        {
            _character = characterBase;
        }

        private void Update()
        {
            if (verticalVelocity < 0 && _character.CharacterController.isGrounded)
            {
                verticalVelocity = Physics.gravity.y * Time.deltaTime;
            }
            else
            {
                verticalVelocity += Physics.gravity.y * Time.deltaTime;
            }

            impact = Vector3.SmoothDamp(impact, Vector3.zero, ref dampingVelocity, _drag);
            if (impact.sqrMagnitude < 0.2f * 0.2f && _agent)
            {
                impact = Vector3.zero;
                _agent.enabled = true;
            }
        }

        public void AddForce(Vector3 force)
        {
            impact += force;
            if (_agent) _agent.enabled = false;
        }

        /// <summary>
        /// 获取输入的移动值
        /// </summary>
        /// <returns></returns>
        public Vector2 GetMovement()
        {
            return _character.InputComponent.MoveValue;
        }

        /// <summary>
        /// 移动
        /// </summary>
        /// <param name="motion"></param>
        /// <param name="deltaTime"></param>
        public void Move(Vector3 motion, float deltaTime)
        {
            _character.CharacterController.Move((motion + MoveMent) * deltaTime);
        }

        /// <summary>
        /// 根据输入计算移动位置
        /// </summary>
        /// <param name="vector2"></param>
        /// <returns></returns>
        public Vector3 CalculateMovement(Vector2 vector2)
        {
            var transform1 = _character.transform;
            var forward = transform1.forward;
            var right = transform1.right;
            forward.y = 0;
            right.y = 0;
            forward.Normalize();
            right.Normalize();
            return forward * vector2.y + right * vector2.x;
        }

        /// <summary>
        /// 根据移动的位置，让角色朝向移动的位置
        /// </summary>
        /// <param name="movement"></param>
        /// <param name="deltaTime"></param>
        public void FaceMovementDirection(Vector3 movement, float deltaTime)
        {
            _character.transform.rotation = Quaternion.Lerp(_character.transform.rotation,
                Quaternion.LookRotation(movement), deltaTime * _character.CharacterData.RotationDamping);
        }
    }
}