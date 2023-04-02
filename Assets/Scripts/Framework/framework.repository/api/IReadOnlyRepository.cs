using System.Collections.Generic;

namespace Framework.framework.repository
{
    public interface IReadOnlyRepository<in TKey, T>
    {
        List<T> GetAll();
        T Get(TKey id);
    }
}