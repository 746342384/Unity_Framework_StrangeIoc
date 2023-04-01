using System.Collections.Generic;
using Cysharp.Threading.Tasks;

namespace Framework.framework.repository.api
{
    public interface IConfigLoader
    {
        string BasePath { get; set; }

        UniTask<List<T>> LoadConfigData<T>(string fileName);
    }
}