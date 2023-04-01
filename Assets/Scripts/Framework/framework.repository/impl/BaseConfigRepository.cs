using System.Collections.Generic;
using System.Linq;
using Framework.framework.repository.api;

namespace Framework.framework.repository.impl
{
    public abstract class BaseConfigRepository<TKey, T> : IConfigRepository<TKey, T> where T : new()
    {
        private readonly IConfigLoader _configLoader;
        private Dictionary<TKey, T> _configDataDictionary;
        protected abstract string ConfigName { get; }

        protected abstract TKey GetId(T item);

        protected BaseConfigRepository(IConfigLoader configLoader)
        {
            _configLoader = configLoader;
        }

        public List<T> GetAll()
        {
            return _configDataDictionary.Values.ToList();
        }

        public T Get(TKey id)
        {
            _configDataDictionary.TryGetValue(id, out var result);
            return result;
        }

        public async void Initialize()
        {
            var loadConfigData = await _configLoader.LoadConfigData<T>(ConfigName);
            _configDataDictionary = loadConfigData.ToDictionary(GetId);
        }
    }
}