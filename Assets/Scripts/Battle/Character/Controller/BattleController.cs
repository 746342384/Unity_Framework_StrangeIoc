using System.Collections.Generic;
using Battle.Character.Base;
using Battle.Enemy;
using UnityEngine;

namespace Battle.Character.Controller
{
    public class BattleController: MonoBehaviour
    {
        public List<CharacterBase> Characters; //所有角色列表
        public List<EnemyBase> Enemies; //所有敌人列表
        public float CollisionRadius; //碰撞检测半径

        public void SpawnEnemy(EnemyBase enemy)
        {
            //实现敌人生成逻辑
        }

        public void CheckCollisions()
        {
            //实现碰撞检测和伤害计算逻辑
        }

        public void CheckSkillCooldown()
        {
            //实现技能冷却时间逻辑
        }
    }
}