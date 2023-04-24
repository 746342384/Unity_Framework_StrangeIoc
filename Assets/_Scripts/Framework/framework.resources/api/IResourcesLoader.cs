using System;
using Cysharp.Threading.Tasks;

namespace Framework.framework.resources.api
{
    public interface IResourcesLoader
    {
        T Load<T>(string path) where T : class;
        T Load<T>(string path, Type type) where T : class;
        UniTask<T> LoadAsync<T>(string path) where T : class;
        UniTask<T> LoadAsync<T>(string path, Type type) where T : class;
        object[] LoadAll(string path);
        object[] LoadAll(string path, Type type);
        UniTask<object[]> LoadAllAsync(string path);
        UniTask<object[]> LoadAllAsync(string path, Type type);
        void Realease(UnityEngine.Object gameObject);
        void RealeaseInstance(UnityEngine.GameObject gameObject);
    }
}