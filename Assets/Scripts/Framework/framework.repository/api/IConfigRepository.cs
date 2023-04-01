using System.Collections.Generic;

namespace Framework.framework.repository.api
{
    public interface IConfigRepository<in TKey, T>
    {
        List<T> GetAll();
        T Get(TKey id);
        void Initialize();
    }
}