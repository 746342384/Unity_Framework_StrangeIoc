using System.Threading.Tasks;

namespace Framework.framework.repository
{
    public interface IConfigRepository<in TKey, T>
    {
        Task Initialize();
    }
}