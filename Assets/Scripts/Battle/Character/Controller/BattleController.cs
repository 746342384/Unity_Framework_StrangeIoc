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

        public void SpawnEnemy(EnemyBase enemy)
        {
            //实现敌人生成逻辑
        }
    }
}