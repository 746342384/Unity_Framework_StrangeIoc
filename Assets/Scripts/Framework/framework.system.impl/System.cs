using System.Collections.Generic;
using System.Threading.Tasks;
using Framework.framework.system.api;
using Root;
using UnityEngine;

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
            Debug.Log($"System OnInit Start");
            foreach (var system in _systems)
            {
                system.OnInit();
            }

            Debug.Log($"System OnInit End");
        }

        public async Task OnInitAsync()
        {
            Debug.Log($"System OnInitAsync Start");
            foreach (var system in _systems)
            {
                await system.OnInitAsync();
            }

            Debug.Log($"System OnInitAsync End");
        }

        public void AddSystem<TSystem>(TSystem system) where TSystem : ISystem
        {
            _systems.Add(system);
        }

        public void BindSystem<TISystem, TSystem>() where TISystem : ISystem
        {
            _gameContext.InjectionBinder.Bind<TISystem>().To<TSystem>().ToSingleton();
            var system = _gameContext.InjectionBinder.GetInstance<TISystem>();
            _systems.Add(system);
        }
    }
}