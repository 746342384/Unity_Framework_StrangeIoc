using System;

namespace Battle.Character.Base.Component
{
    [Serializable]
    public class AttributeComponent
    {
        public float MaxHp;
        public float Hp;

        public void Init(CharacterData characterData)
        {
            MaxHp = characterData.HP;
            Hp = MaxHp;
        }
    }
}