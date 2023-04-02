using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Framework.framework.repository
{
    public class ResourcesConfigLoader : IConfigLoader
    {
        public string BasePath { get; set; }

        public async UniTask<List<T>> LoadConfigData<T>(string fileName)
        {
            var fullPath = $"{BasePath}/{fileName}";
            var textAsset = await LoadTextAssetFromResourcesAsync(fullPath);
            if (textAsset != null)
            {
                Debug.Log($"LoadConfigData:{fileName}:{textAsset.text}");
                var loadConfigData = LitJson.JsonMapper.ToObject<List<T>>(textAsset.text);
                return loadConfigData;
            }

            Debug.LogError($"ResourcesConfigLoader {typeof(T)} is null path {fullPath}");
            return new List<T>();
        }

        private async UniTask<TextAsset> LoadTextAssetFromResourcesAsync(string fileName)
        {
            var request = Resources.LoadAsync<TextAsset>(fileName);
            await UniTask.WaitUntil(() => request.isDone);
            return request.asset as TextAsset;
        }
    }
}