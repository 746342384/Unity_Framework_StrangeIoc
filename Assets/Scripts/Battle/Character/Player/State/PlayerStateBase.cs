using Battle.Character.Base;
using Battle.Character.Base.Component;
using UnityEngine;

namespace Battle.Character.Player.State
{
    public abstract class PlayerStateBase : StateBase
    {
        private Vector3 TargetPosition;
        private Vector3 NewPosition;
        private Vector3 StartPosition;
        protected readonly CharacterBase Character;

        protected PlayerStateBase(CharacterBase character)
        {
            Character = character;
        }

        /// <summary>
        /// 移动
        /// </summary>
        /// <param name="motion"></param>
        /// <param name="deltaTime"></param>
        protected void Move(Vector3 motion, float deltaTime)
        {
            var moveMent = Character.MoveMent;
            Character.CharacterController.Move((motion + moveMent) * deltaTime);
        }

        /// <summary>
        /// 根据输入计算移动位置
        /// </summary>
        /// <param name="vector2"></param>
        /// <returns></returns>
        protected Vector3 CalculateMovement(Vector2 vector2)
        {
            var transform1 = Character.transform;
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
        protected void FaceMovementDirection(Vector3 movement, float deltaTime)
        {
            Character.transform.rotation = Quaternion.Lerp(Character.transform.rotation,
                Quaternion.LookRotation(movement), deltaTime * Character.CharacterData.RotationDamping);
        }

        /// <summary>
        /// 获取输入的移动值
        /// </summary>
        /// <returns></returns>
        protected Vector2 GetMovement()
        {
            return Character.InputComponent.MoveValue;
        }

        /// <summary>
        /// 设置在播放特定动画的时候角色前后移动的距离
        /// </summary>
        /// <param name="distance"></param>
        protected void SetMoveForwardTarget(float distance)
        {
            var transform = Character.transform;
            var position = transform.position;
            var forward = transform.forward;
            forward.y = 0.0f;
            forward.Normalize();
            TargetPosition = position + forward * distance;
            StartPosition = position;
        }
        
        /// <summary>
        /// 设置在播放特定动画的时候角色左右移动的距离
        /// </summary>
        /// <param name="distance"></param>
        protected void SetMoveRightTarget(float distance)
        {
            var transform = Character.transform;
            var position = transform.position;
            var right = transform.right;
            right.x = 0.0f;
            right.Normalize();
            TargetPosition = position + right * distance;
            StartPosition = position;
        }

        /// <summary>
        /// 根据动画播放的时间向前插值移动
        /// </summary>
        /// <param name="normalizedTime"></param>
        protected bool LerpMoveToTarget(float normalizedTime)
        {
            NewPosition = Vector3.Lerp(StartPosition, TargetPosition, normalizedTime);
            Character.transform.position = NewPosition;
            return true;
        }
    }
}