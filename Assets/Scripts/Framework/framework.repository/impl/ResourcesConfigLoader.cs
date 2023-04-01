using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Framework.framework.repository.api;
using UnityEngine;

namespace Framework.framework.repository.impl
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
                return JsonUtility.FromJson<List<T>>(textAsset.text);
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