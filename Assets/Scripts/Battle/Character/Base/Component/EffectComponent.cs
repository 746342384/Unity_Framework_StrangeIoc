using Extensions;
using Framework.framework.resources.api;
using UnityEngine;

namespace Battle.Character.Base.Component
{
    public class EffectComponent : MonoBehaviour
    {
        private IResourceSystemService _resourceSystemService;

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
    }
}