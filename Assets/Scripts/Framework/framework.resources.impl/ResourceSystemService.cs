using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Framework.framework.resources.api;

namespace Framework.framework.resources.impl
{
    public class ResourceSystemService : IResourceSystemService
    {
        private readonly IResourcesLoader _resourcesLoader;
        private Dictionary<string, object> _cache = new();

        public ResourceSystemService(IResourcesLoader resourcesLoader)
        {
            _resourcesLoader = resourcesLoader;
        }

        public void Clear()
        {
            _cache.Clear();
        }

        public object Load(string path, Type type)
        {
            return _cache.TryGetValue(path, out var obj) ? obj : _resourcesLoader.Load(path, type);
        }

        public T Load<T>(string path, Type type) where T : class
        {
            return _cache.TryGetValue(path, out var obj) ? obj as T : _resourcesLoader.Load<T>(path);
        }

        public async Task<object> LoadAsync(string path, Type type)
        {
            return _cache.TryGetValue(path, out var obj) ? obj : await _resourcesLoader.LoadAsync(path, type);
        }

        public async Task<T> LoadAsync<T>(string path, Type type) where T : class
        {
            return _cache.TryGetValue(path, out var obj) ? obj as T : await _resourcesLoader.LoadAsync<T>(path);
        }
    }
}