using System;
using Battle.Character.Base;
using UnityEngine;

namespace Battle.Character
{
    [Serializable]
    [CreateAssetMenu(fileName = nameof(AttackData), menuName = "ScriptableObjects/AttackData", order = 1)]
    public class AttackData : ScriptableObject
    {
        [Header("攻击动画名")] public string AnimationName;
        [Header("攻击时施加的力")] public float AddForce;
        [Header("攻击动画开始播放的时间")] [Range(0, 1f)] public float Time;
        [Header("攻击音效开始播放的时间")] [Range(0, 1f)] public float AttackSfxTime;
        [Header("攻击音效")] public AudioClip AttackSfx;
        [Header("攻击检测开始的时间")] [Range(0, 1f)] public float AttackStart;
        [Header("攻击检测结束的时间")] [Range(0, 1f)] public float AttackEnd = 1f;
        [Header("攻击伤害")] public float AtkValue;
        [Header("攻击武器特效")] public GameObject AttackWeaponEfx;
        [Header("攻击特效开始释放时间")] [Range(0, 1)] public float AttackEfxTime;
        [Header("攻击特效")] public GameObject AttackEfx;
        [Header("攻击特效层级")] public EffectParent EffectParent = EffectParent.Bottom;
        [Header("攻击特效持续时间")] public float AttackEfxDuration = 1f;
    }
}