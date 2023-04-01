using System.Collections.Generic;
using Cysharp.Threading.Tasks;

namespace Framework.framework.addressable.api
{
    public interface IAddressableDownload
    {
        UniTask StartPreDownload();
        IEnumerable<string> GetGroups();
    }
}