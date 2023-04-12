using System.Collections.Generic;
using UnityEngine;

namespace Battle.Character
{
    [CreateAssetMenu(fileName = "CharacterData", menuName = "ScriptableObjects/CharacterData", order = 1)]
    public class CharacterData : ScriptableObject
    {
        [Header("角色移动速度")] public float MoveSpeed;
        public float HP;
        [Header("角色普通攻击")] public List<AttackData> AttackDatas = new();
        [Header("旋转速度")] public float RotationDamping;
        [Header("向前翻滚施加力")] public float RollForwardAddForce;
        [Header("向后翻滚施加力")] public float RollBackwardAddForce;
        [Header("向左翻滚施加力")] public float RollLeftAddForce;
        [Header("向右翻滚施加力")] public float RollRightAddForce;
        [Header("向前跳跃施加力")] public float RunningJumpAddForce;
    }
}