using System.Collections.Generic;
using Framework.framework.system.api;
using Root;
using strange.extensions.injector.api;

namespace Framework.framework.system.impl
{
    public class System
    {
        private readonly ICrossContextInjectionBinder _injectionBinder;
        private readonly IGameContext _context;
        private List<ISystem> _systems = new List<ISystem>();

        public System(IGameContext context)
        {
            _context = context;
            _injectionBinder = _context.ContextInjectionBinder;
        }

        public void BindSystem<TSystem, TSystemImpl>() where TSystemImpl : ISystem
        {
            _injectionBinder.Bind<TSystem>().To<TSystemImpl>().CrossContext().ToSingleton();
            var system = _injectionBinder.GetInstance<TSystemImpl>();
            _systems.Add(system);
        }

        public void OnInit()
        {
            foreach (var system in _systems)
            {
                system.OnInit();
            }
        }
    }
}