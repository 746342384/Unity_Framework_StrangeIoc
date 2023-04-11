using UnityEngine;

namespace Battle.Character
{
    [CreateAssetMenu(fileName = "AttackData", menuName = "ScriptableObjects/AttackData", order = 1)]
    public class AttackData : ScriptableObject
    {
        public string AnimationName;
        public float Time;
    }
}