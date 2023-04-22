using Extensions;
using Framework.framework.resources.api;
using UnityEngine;

namespace Battle.Character.Base.Component
{
    public class EffectComponent : MonoBehaviour
    {
        private IResourceSystemService _resourceSystemService;

        public Transform BottomParent;
        public Transform TopParent;
        public Transform MiddleParent;
        public Transform HeadParent;
        public Transform LeftHandParent;
        public Transform RightHandParent;
        public Transform LeftFootParent;
        public Transform RightFootParent;

        private void Start()
        {
            _resourceSystemService =
                GameContext.Instance.GetComponent<IResourceSystemService>() as IResourceSystemService;
        }

        public async void PlayerAttackEfxAsync(string path, Transform parent, Vector3 pos)
        {
            var prefab = await _resourceSystemService.LoadAsync<GameObject>(path);
            var obj = Instantiate(prefab, parent);
            obj.SetScale(Vector3.one);
            obj.SetPostion(pos);
        }

        public void PlayerAttackEfx(GameObject attackDataAttackEfx, float duration, EffectParent attackDataEffectParent)
        {
            if (attackDataAttackEfx == null) return;
            var parent = GetEffectParent(attackDataEffectParent);
            var obj = Instantiate(attackDataAttackEfx, parent);
            obj.SetScale(Vector3.one);
            Destroy(obj, duration);
        }

        private Transform GetEffectParent(EffectParent effectParent)
        {
            switch (effectParent)
            {
                case EffectParent.Top:
                    return TopParent;
                case EffectParent.Middle:
                    return MiddleParent;
                case EffectParent.Bottom:
                    return BottomParent;
                case EffectParent.Head:
                    return HeadParent;
                case EffectParent.LeftHand:
                    return LeftHandParent;
                case EffectParent.RightHand:
                    return RightHandParent;
                case EffectParent.LeftFoot:
                    return LeftFootParent;
                case EffectParent.RightFoot:
                    return RightFootParent;
                default:
                    return BottomParent;
            }
        }
    }
}