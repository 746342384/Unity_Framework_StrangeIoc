using System.Threading.Tasks;
using UnityEngine;

namespace Framework.framework.resources.api
{
    public interface IResourceSystemService
    {
        void Clear();
        void Realease(GameObject gameObject);
        void Realease(string key);
        Task<T> LoadAsync<T>(string path) where T : class;
    }
}