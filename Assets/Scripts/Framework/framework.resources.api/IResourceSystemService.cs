using System;
using System.Threading.Tasks;

namespace Framework.framework.resources.api
{
    public interface IResourceSystemService
    {
        void Clear();
        object Load(string path,Type type);
        T Load<T>(string path, Type type) where T: class;
        Task<object> LoadAsync(string path, Type type);
        Task<T> LoadAsync<T>(string path, Type type) where T : class;
    }
}