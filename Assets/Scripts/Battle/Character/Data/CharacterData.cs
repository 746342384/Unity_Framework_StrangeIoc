using UnityEngine;

namespace Battle.Character
{
    [CreateAssetMenu(fileName = "CharacterData", menuName = "ScriptableObjects/CharacterData", order = 1)]
    public class CharacterData : ScriptableObject
    {
        public float MoveSpeed;
        public float Attack;
        public float Defense;
        public float HP;
        [Header("旋转速度")] public float RotationDamping;
        [Header("向前翻滚距离")] public float RollForwardDistance;
        [Header("向后翻滚距离")] public float RollBackwardDistance;
        [Header("向左翻滚距离")] public float RollLeftDistance;
        [Header("向右翻滚距离")] public float RollRightDistance;
        [Header("向前跳跃距离")] public float RunningJumpDistance;
    }
}