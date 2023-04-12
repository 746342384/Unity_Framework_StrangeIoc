using UnityEngine;

namespace Battle.Character
{
    [CreateAssetMenu(fileName = "AttackData", menuName = "ScriptableObjects/AttackData", order = 1)]
    public class AttackData : ScriptableObject
    {
        public string AnimationName;
        [Range(0, 1f)] public float Time;
        [Range(0, 1f)] public float AttackSfxTime;
        public AudioClip AttackSfx;
    }
}