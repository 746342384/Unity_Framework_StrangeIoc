using Battle.Character.Base;
using UnityEngine;

namespace Battle.Skill
{
    public class SkillBase : MonoBehaviour
    {
        public string Name; //技能名称
        public int Damage; //技能伤害
        public float Cooldown; //技能冷却时间
        public GameObject Effect; //技能特效
        public float CooldownTimer;

        public void Cast(CharacterBase caster, CharacterBase target)
        {
            //实现技能释放逻辑
            target.CharacterData.HP -= Damage;
            Instantiate(Effect, target.transform.position, Quaternion.identity);
        }
    }
}