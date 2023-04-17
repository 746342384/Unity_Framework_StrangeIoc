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

        public void PlayerAttackEfx(GameObject attackDataAttackEfx, float duration)
        {
            if (attackDataAttackEfx == null) return;
            var obj = Instantiate(attackDataAttackEfx, BottomParent);
            obj.SetScale(Vector3.one);
            Destroy(obj, duration);
        }
    }
}