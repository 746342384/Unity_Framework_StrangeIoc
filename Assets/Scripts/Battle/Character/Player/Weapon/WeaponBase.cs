using System;
using System.Linq;
using Battle.Character.Base;
using Battle.Enemy;
using UnityEngine;

namespace Battle.Character.Player.Weapon
{
    public class WeaponBase : MonoBehaviour
    {
        public Transform Root;
        public Collider Collider;
        private CharacterBase _characterBase;

        public void Init(CharacterBase characterBase)
        {
            _characterBase = characterBase;
        }

        public void EnableCollider()
        {
            Collider.enabled = true;
        }

        public void DisableCollider()
        {
            Collider.enabled = false;
        }

        public float offset;
        public float height;

        private void Update()
        {
            if (Collider.enabled)
            {
                var attackDistance =
                    _characterBase.CharacterData.AttackDatas[_characterBase.AttackIndex].AttackDistance;
                if (Physics.Raycast(transform.position, transform.right, out var hitInfo,
                        attackDistance,
                        LayerMask.GetMask("Enemy")))
                {
                    var enemy = hitInfo.collider.GetComponent<EnemyBase>();
                    if (enemy != null)
                    {
                        Time.timeScale = 0.00f;
                        Debug.Log("碰撞到敌人");
                    }
                }

                var position = transform.position;
                var up = transform.up;
                var start = position + up * offset; // 起点为武器刀锋位置
                var end = position + up * (offset + height); // 终点为武器刀锋位置加上长度
                Debug.DrawLine(start, end, Color.red, 1.0f);
                Debug.DrawRay(position, transform.right * attackDistance, Color.blue, 1.0f);
            }
        }
    }
}