using System;
using Cysharp.Threading.Tasks;
using Framework.framework.resources.api;
using UnityEngine.AddressableAssets;
using Object = UnityEngine.Object;

namespace Framework.framework.resources.impl
{
    public class AddressableLoader : IResourcesLoader
    {
        public T Load<T>(string path) where T : class
        {
            return default;
        }

        public T Load<T>(string path, Type type) where T : class
        {
            return Load<T>(path);
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
            throw new NotImplementedException();
        }

        public object[] LoadAll(string path, Type type)
        {
            throw new NotImplementedException();
        }

        public UniTask<object[]> LoadAllAsync(string path)
        {
            throw new NotImplementedException();
        }

        public UniTask<object[]> LoadAllAsync(string path, Type type)
        {
            throw new NotImplementedException();
        }

        public void Realease(Object gameObject)
        {
            Addressables.Release(gameObject);
        }
    }
}