using System;
using System.Linq;
using Cysharp.Threading.Tasks;
using Framework.framework.resources.api;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Framework.framework.resources.impl
{
    public class AddressableLoader : IResourcesLoader
    {
        public object Load(string path)
        {
            return Addressables.LoadAssetAsync<GameObject>(path);
        }

        public object Load(string path, Type type)
        {
            return Resources.Load(path, type);
        }

        public T Load<T>(string path) where T : class
        {
            var type = typeof(T);
            return Resources.Load(path, type) as T;
        }

        public T Load<T>(string path, Type type) where T : class
        {
            return Resources.Load(path, type) as T;
        }

        public async UniTask<object> LoadAsync(string path)
        {
            return await Addressables.LoadAssetAsync<GameObject>(path).ToUniTask();
        }

        public async UniTask<object> LoadAsync(string path, Type type)
        {
            return await Addressables.LoadAssetAsync<GameObject>(path).ToUniTask();
        }

        public async UniTask<T> LoadAsync<T>(string path) where T : class
        {
            return await Addressables.LoadAssetAsync<T>(path).ToUniTask();
        }

        public async UniTask<T> LoadAsync<T>(string path, Type type) where T : class
        {
            return await Addressables.LoadAssetAsync<T>(path).ToUniTask();
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
            return await UniTask.FromResult(Resources.LoadAll(path, type)?.Cast<object>().ToArray());
        }
    }
}