using System.Collections.Generic;
using System.Threading.Tasks;
using Framework.framework.resources.api;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Framework.framework.resources.impl
{
    public class ResourceSystemService : IResourceSystemService
    {
        private readonly IResourcesLoader _resourcesLoader;
        private Dictionary<string, Object> _cache = new();

        public ResourceSystemService(IResourcesLoader resourcesLoader)
        {
            _resourcesLoader = resourcesLoader;
        }

        public void Clear()
        {
            _cache.Clear();
        }

        public void Realease(GameObject gameObject)
        {
            _resourcesLoader.Realease(gameObject);
        }

        public void Realease(string key)
        {
            if (_cache.TryGetValue(key, out var value))
            {
                _resourcesLoader.Realease(value);
            }
        }
        
        public async Task<T> LoadAsync<T>(string path) where T : class
        {
            return _cache.TryGetValue(path, out var obj) ? obj as T : await _resourcesLoader.LoadAsync<T>(path);
        }
    }
}