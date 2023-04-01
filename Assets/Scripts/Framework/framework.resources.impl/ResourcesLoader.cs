using System;
using System.Linq;
using Cysharp.Threading.Tasks;
using Framework.framework.resources.api;
using UnityEngine;

namespace Framework.framework.resources.impl
{
    public class ResourcesLoader : IResourcesLoader
    {
        
        public T Load<T>(string path) where T : class
        {
            var type = typeof(T);
            return Resources.Load(path, type) as T;
        }

        public T Load<T>(string path, Type type) where T : class
        {
            return Resources.Load(path, type) as T;
        }

        public async UniTask<T> LoadAsync<T>(string path) where T : class
        {
            var type = typeof(T);
            return await Resources.LoadAsync(path, type).ToUniTask() as T;
        }

        public async UniTask<T> LoadAsync<T>(string path, Type type) where T : class
        {
            return await Resources.LoadAsync(path, type).ToUniTask() as T;
        }

        public object[] LoadAll(string path)
        {
            return Resources.LoadAll(path).Cast<object>().ToArray();
        }

        public object[] LoadAll(string path, Type type)
        {
            return Resources.LoadAll(path, type).Cast<object>().ToArray();
        }

        public async UniTask<object[]> LoadAllAsync(string path)
        {
            return await UniTask.FromResult(Resources.LoadAll(path)?.Cast<object>().ToArray());
        }

        public async UniTask<object[]> LoadAllAsync(string path, Type type)
        {
            return await UniTask.FromResult(Resources.LoadAll(path,type)?.Cast<object>().ToArray());
        }

        public void Realease(UnityEngine.Object gameObject)
        {
            Resources.UnloadAsset(gameObject);
        }
    }
}