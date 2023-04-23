using System.Collections.Generic;
using Battle.Character.Base;
using Battle.Enemy;
using UnityEngine;

namespace Battle.Character.Weapon
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

        public void ClearTargets()
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
            var mask = LayerMask.GetMask(_characterBase.CharacterType == CharacterType.Enemy ? "Player" : "Enemy");
            var numOfRays = Spline.points.Count - 1;
            for (var i = 0; i < numOfRays; i++)
            {
                var rayOrigin = Spline.points[i].position;
                var rayNext = Spline.points[i + 1].position;
                var bladeDirection = (rayNext - rayOrigin).normalized;
                var dir = Vector3.Distance(rayOrigin, rayNext);
                if (Physics.Raycast(rayOrigin, bladeDirection, out var hit, dir, mask))
                {
                    var characterBase = hit.collider.gameObject.GetComponent<CharacterBase>();
                    if (characterBase != null)
                    {
                        Time.timeScale = _characterBase.CharacterData.WeaponData.AttackStopStep;
                        AddTarget(characterBase, hit);
                        Debug.DrawRay(rayOrigin, bladeDirection * dir, Color.blue, 1.0f);
                        break;
                    }
                }

                Debug.DrawRay(rayOrigin, bladeDirection * dir, Color.blue, 1.0f);
            }
        }

        private void AddTarget(CharacterBase characterBase, RaycastHit raycastHit)
        {
            if (!TarGets.Contains(characterBase))
            {
                Debug.Log("击中敌人！");
                TarGets.Add(characterBase);
                TakeDamage(characterBase, raycastHit.point);
                PlayAttackEfx(raycastHit.point);
            }
        }

        private void PlayAttackEfx(Vector3 raycastHitPoint)
        {
            // const string path = "Assets/ResPackage/Common/Prefab/Effect/Sphere.prefab";
            // _characterBase.EffectComponent.PlayerAttackEfxAsync(path, null,
            //     raycastHitPoint);
        }

        private void TakeDamage(CharacterBase enemyBase, Vector3 raycastHitPoint)
        {
            switch (_characterBase.CharacterData.WeaponData.AttackType)
            {
                case AttackType.Single:
                    SingleTakeDamage(enemyBase, raycastHitPoint);
                    break;
            }
        }

        private void SingleTakeDamage(CharacterBase enemyBase, Vector3 raycastHitPoint)
        {
            enemyBase.SingleTakeDamage(_characterBase, AttackDataIndex, raycastHitPoint);
        }
    }
}