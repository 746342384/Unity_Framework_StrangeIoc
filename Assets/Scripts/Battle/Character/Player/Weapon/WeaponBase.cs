using System;
using Battle.Character.Base;
using Battle.Enemy;
using UnityEngine;

namespace Battle.Character.Player.Weapon
{
    [RequireComponent(typeof(BezierSpline))]
    public class WeaponBase : MonoBehaviour
    {
        public Transform Root;
        public Collider Collider;
        private CharacterBase _characterBase;
        public BezierSpline Spline;

        private void Awake()
        {
            Spline = GetComponent<BezierSpline>();
        }

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

        private void Update()
        {
            if (Collider.enabled)
            {
                PerformAttack();
            }
        }


        public int numOfRays = 5;

        void PerformAttack()
        {
            var attackDistance = _characterBase.CharacterData.AttackDatas[_characterBase.AttackIndex].AttackDistance;
            var mask = LayerMask.GetMask("Enemy");
            for (var i = 0; i < numOfRays; i++)
            {
                var t = (float)i / (numOfRays - 1); // 计算当前射线在曲线上的位置百分比
                var rayOrigin = Spline.GetPoint(t); // 计算当前射线的起始位置
                var bladeDirection = (Spline.GetPoint(t + 0.01f) - rayOrigin).normalized; // 计算刀锋方向
                if (Physics.Raycast(rayOrigin, bladeDirection, out var hit, attackDistance, mask))
                {
                    if (hit.collider.gameObject.GetComponent<EnemyBase>() != null)
                    {
                        Debug.Log("击中敌人！");
                        break;
                    }
                }

                Debug.DrawRay(rayOrigin, bladeDirection * attackDistance, Color.blue, 1.0f);
            }
        }

        // private void OnDrawGizmos()
        // {
        //     if (_characterBase != null)
        //     {
        //         var attackDistance =
        //             _characterBase.CharacterData.AttackDatas[_characterBase.AttackIndex].AttackDistance;
        //         Gizmos.color = Color.blue;
        //         Gizmos.DrawRay(transform.position, transform.right * attackDistance);
        //     }
        // }
    }
}