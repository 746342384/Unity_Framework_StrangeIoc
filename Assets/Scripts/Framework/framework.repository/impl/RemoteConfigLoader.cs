using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Framework.framework.log;
using UnityEngine.Networking;

namespace Framework.framework.repository
{
    public class RemoteConfigLoader : IConfigLoader
    {
        private readonly ILog _log;

        public RemoteConfigLoader(ILog log)
        {
            _log = log;
        }

        public string BasePath { get; set; }

        public async UniTask<List<T>> LoadConfigData<T>(string fileName)
        {
            var fullPath = $"{BasePath}/{fileName}.json";
            var json = await DownloadJsonAsync(fullPath);
            if (!string.IsNullOrEmpty(json))
            {
                _log.Debug($"LoadConfigData:{fileName}:{json}");
                return LitJson.JsonMapper.ToObject<List<T>>(json);
            }

            _log.Error($"RemoteConfigLoader {typeof(T)} is null url {fullPath}");
            return new List<T>();
        }

        private async UniTask<string> DownloadJsonAsync(string url)
        {
            using var request = UnityWebRequest.Get(url);
            try
            {
                await request.SendWebRequest();

                if (request.result is
                    UnityWebRequest.Result.ConnectionError or
                    UnityWebRequest.Result.ProtocolError or
                    UnityWebRequest.Result.DataProcessingError)
                {
                    _log.Error($"Error downloading JSON data: {request.error}");
                    return null;
                }

                return request.downloadHandler.text;
            }
            catch (UnityWebRequestException e)
            {
                _log.Error($"{e.Error},{e.UnityWebRequest.url}");
                return null;
            }
        }
    }
}