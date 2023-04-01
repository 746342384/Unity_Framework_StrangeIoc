using System.Threading.Tasks;

namespace Framework.framework.system.api
{
    public interface ISystem
    {
        void OnInit();
        Task OnInitAsync();
    }
}