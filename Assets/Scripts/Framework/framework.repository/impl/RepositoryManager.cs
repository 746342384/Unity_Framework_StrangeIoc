using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Framework.framework.attribute;
using Framework.framework.log;
using strange.extensions.injector.api;
using UnityEngine;

namespace Framework.framework.repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly IConfigLoader _configLoader;
        private readonly IInjectionBinder _injectionBinder;
        private readonly ILog _log;

        public RepositoryManager(IConfigLoader configLoader,
            IInjectionBinder injectionBinder,
            ILog log)
        {
            _log = log;
            _injectionBinder = injectionBinder;
            _configLoader = configLoader;
        }

        public async Task LoadRepositories()
        {
            var request = Resources.LoadAsync<LoaderDataConfig>("ConfigData");
            await UniTask.WaitUntil(() => request.isDone);
            var config = request.asset as LoaderDataConfig;
            if (config != null)
                _configLoader.BasePath = config.ConfigLoaderMode switch
                {
                    ConfigLoaderMode.Remote => config.Remote,
                    ConfigLoaderMode.Local => config.Local,
                    ConfigLoaderMode.Db => config.Db,
                    _ => throw new ArgumentOutOfRangeException()
                };
            else
            {
                return;
            }

            var types = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(type => type.IsClass && !type.IsAbstract &&
                               type.GetCustomAttributes(typeof(RepositoryAttribute), true).Length > 0)
                .ToArray();

            var initializeTasks = new List<UniTask>();
            foreach (var repositoryType in types)
            {
                var customAttributes = repositoryType.GetCustomAttribute<RepositoryAttribute>();
                var repositoryInstance = Activator.CreateInstance(repositoryType, _configLoader, _log);
                var initializeMethod = repositoryType.GetMethod("Initialize");
                if (initializeMethod != null)
                {
                    var task = (Task)initializeMethod.Invoke(repositoryInstance, null);
                    initializeTasks.Add(task.AsUniTask());
                }

                _injectionBinder.Bind(customAttributes.Type).To(repositoryInstance).ToSingleton().CrossContext();
            }

            await UniTask.WhenAll(initializeTasks);
        }
    }
}