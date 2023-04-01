using System.Threading.Tasks;
using Framework.framework.system.api;

namespace Framework.framework.system.impl
{
    public abstract class SystemBase : ISystem
    {
        public virtual void OnInit()
        {
        }

        public virtual Task OnInitAsync()
        {
            return Task.FromResult(Task.CompletedTask);
        }
    }
}