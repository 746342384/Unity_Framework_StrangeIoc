using System.Collections.Generic;
using Framework.framework.system.api;
using Root;

namespace Framework.framework.system.impl
{
    public class System
    {
        private readonly List<ISystem> _systems = new();
        private IGameContext _gameContext { get; set; }

        public void Init(IGameContext gameContext)
        {
            _gameContext = gameContext;
        }

        public void OnInit()
        {
            foreach (var system in _systems)
            {
                system.OnInit();
            }
        }

        public void BindSystem<TISystem, TSystem>() where TISystem : ISystem
        {
            _gameContext.InjectionBinder.Bind<TISystem>().To<TSystem>().ToSingleton();
            var system = _gameContext.InjectionBinder.GetInstance<TISystem>();
            _systems.Add(system);
        }
    }
}