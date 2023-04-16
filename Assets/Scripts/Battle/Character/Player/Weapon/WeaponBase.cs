using System;
using System.Collections.Generic;
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
        public List<CharacterBase> TarGets = new();
        private bool _isAttacking;
        public int AttackDataIndex;

        private void Awake()
        {
            Spline = GetComponent<BezierSpline>();
        }

        public void Init(CharacterBase characterBase)
        {
            _characterBase = characterBase;
        }

        public void StartAttack()
        {
            _isAttacking = true;
        }

        public void EndAttack()
        {
            _isAttacking = false;
            ClearTargets();
        }

        private void ClearTargets()
        {
            TarGets.Clear();
        }

        private void FixedUpdate()
        {
            if (_isAttacking)
            {
                PerformAttack();
            }
        }

        private void PerformAttack()
        {
            var mask = LayerMask.GetMask("Enemy");
            var numOfRays = Spline.points.Count - 1;
            for (var i = 0; i < numOfRays; i++)
            {
                var rayOrigin = Spline.points[i].position;
                var rayNext = Spline.points[i + 1].position;
                var bladeDirection = (rayNext - rayOrigin).normalized;
                var dir = Vector3.Distance(rayOrigin, rayNext);
                if (Physics.Raycast(rayOrigin, bladeDirection, out var hit, dir, mask))
                {
                    var enemyBase = hit.collider.gameObject.GetComponent<EnemyBase>();
                    if (enemyBase != null)
                    {
                        Time.timeScale = _characterBase.CharacterData.WeaponData.AttackStopStep;
                        AddTarget(enemyBase);
                        Debug.DrawRay(rayOrigin, bladeDirection * dir, Color.blue, 1.0f);
                        break;
                    }
                }

                Debug.DrawRay(rayOrigin, bladeDirection * dir, Color.blue, 1.0f);
            }
        }

        private void AddTarget(CharacterBase characterBase)
        {
            if (!TarGets.Contains(characterBase))
            {
                Debug.Log("击中敌人！");
                TarGets.Add(characterBase);
                TakeDamage(characterBase);
            }
        }

        private void TakeDamage(CharacterBase enemyBase)
        {
            switch (_characterBase.CharacterData.WeaponData.AttackType)
            {
                case AttackType.Single:
                    SingleTakeDamage(enemyBase);
                    break;
            }
        }

        private void SingleTakeDamage(CharacterBase enemyBase)
        {
            enemyBase.SingleTakeDamage(_characterBase, AttackDataIndex);
        }
    }
}