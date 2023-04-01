using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Framework.framework.repository.api;
using UnityEngine;
using UnityEngine.Networking;

namespace Framework.framework.repository.impl
{
    public class RemoteConfigLoader : IConfigLoader
    {
        public string BasePath { get; set; }

        public async UniTask<List<T>> LoadConfigData<T>(string fileName)
        {
            var fullPath = $"{BasePath}/{fileName}.json";
            var json = await DownloadJsonAsync(fullPath);
            if (!string.IsNullOrEmpty(json))
            {
                return JsonUtility.FromJson<List<T>>(json);
            }
            Debug.LogError($"RemoteConfigLoader {typeof(T)} is null url {fullPath}");
            return new List<T>();
        }

        private async UniTask<string> DownloadJsonAsync(string url)
        {
            using var request = UnityWebRequest.Get(url);
            await request.SendWebRequest();

            if (request.result is
                UnityWebRequest.Result.ConnectionError or
                UnityWebRequest.Result.ProtocolError or
                UnityWebRequest.Result.DataProcessingError)
            {
                Debug.LogError($"Error downloading JSON data: {request.error}");
                return null;
            }

            return request.downloadHandler.text;
        }
    }
}