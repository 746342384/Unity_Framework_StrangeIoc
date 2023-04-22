using System.Collections.Generic;
using UnityEngine;

namespace Battle.Character
{
    [CreateAssetMenu(fileName = nameof(CharacterData), menuName = "ScriptableObjects/CharacterData", order = 1)]
    public class CharacterData : ScriptableObject
    {
        public float HP;

        [Header("角色普通攻击")] public List<AttackData> AttackDatas = new();
        [Header("武器配置")] public WeaponData WeaponData;
        [Header("受击动画特效")] public GameObject HittedEfx;

        [Header("施加力平滑移动时间")] public float MoveDrag;
        [Header("角色移动速度")] public float MoveSpeed;
        [Header("旋转速度")] public float RotationDamping;
        [Header("向前翻滚施加力")] public float RollForwardAddForce;
        [Header("向后翻滚施加力")] public float RollBackwardAddForce;
        [Header("向左翻滚施加力")] public float RollLeftAddForce;
        [Header("向右翻滚施加力")] public float RollRightAddForce;

        [Space(20)] [Header("跳跃动作动画名")] public string JumpAnimationName = "Jump";
        [Header("进入跳跃动作过渡时间")] [Range(0, 1)] public float JumpFixedTransitionDuration = 0.2f;
        [Header("跳跃结束时间")] [Range(0, 1)] public float JumpEndTime = 1f;
        [Header("跳跃施加力开始时间")] [Range(0, 1)] public float JumpAddForceStartTime;
        [Header("跳跃施加力")] public float JumpAddForce;
    }
}