using Battle.Character.Weapon;
using UnityEngine;

namespace Battle.Character
{
    [CreateAssetMenu(fileName = nameof(WeaponData), menuName = "ScriptableObjects/WeaponData", order = 1)]
    public class WeaponData : ScriptableObject
    {
        public float AttackStopStep;
        public AttackType AttackType;
    }
}