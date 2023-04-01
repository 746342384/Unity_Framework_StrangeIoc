using System;
using System.Linq;
using System.Reflection;
using Framework.framework.repository.api;
using strange.extensions.injector.api;

namespace Framework.framework.repository.impl
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly IConfigLoader _configLoader;
        private readonly IInjectionBinder _injectionBinder;

        public RepositoryManager(IConfigLoader configLoader,
            IInjectionBinder injectionBinder)
        {
            _injectionBinder = injectionBinder;
            _configLoader = configLoader;
        }

        public void LoadRepositories()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var repositoryTypes = assembly.GetTypes().Where(t =>
                t.IsClass && !t.IsAbstract && t.GetInterfaces().Contains(typeof(IConfigRepository<,>)));
            foreach (var repositoryType in repositoryTypes)
            {
                var repositoryInstance = Activator.CreateInstance(repositoryType, _configLoader);
                var initializeMethod = repositoryType.GetMethod("Initialize");
                initializeMethod?.Invoke(repositoryInstance, null);
                var repositoryInterfaceType = repositoryType.GetInterfaces()[0];
                _injectionBinder.Bind(repositoryInterfaceType).To(repositoryType).ToSingleton().CrossContext();
            }
        }
    }
}