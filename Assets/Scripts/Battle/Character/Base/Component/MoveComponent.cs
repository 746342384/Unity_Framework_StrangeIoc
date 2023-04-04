using UnityEngine;

namespace Battle.Character.Base.Component
{
    public class MoveComponent : MonoBehaviour
    {
        public CharacterBase CharacterBase;

        public void Init(CharacterBase characterBase)
        {
            CharacterBase = characterBase;
        }
    }
}