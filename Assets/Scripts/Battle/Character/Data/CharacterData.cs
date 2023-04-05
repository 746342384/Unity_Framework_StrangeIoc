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
        public float RotationDamping;
    }
}