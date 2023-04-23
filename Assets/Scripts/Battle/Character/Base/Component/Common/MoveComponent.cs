using Battle.Character.Player;
using UnityEngine;
using UnityEngine.AI;

namespace Battle.Character.Base.Component
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class MoveComponent : MonoBehaviour
    {
        private PlayerBase _character;

        public void Init(PlayerBase characterBase)
        {
            _character = characterBase;
        }

        /// <summary>
        /// 获取输入的移动值
        /// </summary>
        /// <returns></returns>
        public Vector2 GetMovement()
        {
            return _character.InputComponent.MoveValue;
        }

        public bool IsMove()
        {
            return !_character.InputComponent.MoveValue.Equals(Vector2.zero);
        }

        /// <summary>
        /// 移动
        /// </summary>
        /// <param name="motion"></param>
        /// <param name="deltaTime"></param>
        public void Move(Vector3 motion, float deltaTime)
        {
            _character.CharacterController.Move((motion + _character.ReceiveForceComponent.MoveMent) * deltaTime);
        }

        /// <summary>
        /// 根据输入计算移动位置
        /// </summary>
        /// <param name="vector2"></param>
        /// <returns></returns>
        public Vector3 CalculateMovement(Vector2 vector2)
        {
            var transform1 = _character.transform;
            if (_character is { } playerBase)
            {
                transform1 = playerBase.MainCameraTransform;
            }

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