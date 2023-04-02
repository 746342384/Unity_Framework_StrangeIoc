using System.Collections.Generic;
using Cysharp.Threading.Tasks;

namespace Framework.framework.repository
{
    public interface IConfigLoader
    {
        string BasePath { get; set; }

        UniTask<List<T>> LoadConfigData<T>(string fileName);
    }
}