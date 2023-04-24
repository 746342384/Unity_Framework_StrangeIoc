using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Framework.framework.log;

namespace Framework.framework.repository
{
    public abstract class BaseConfigRepository<TKey, T> : IConfigRepository<TKey, T> where T : new()
    {
        private readonly IConfigLoader _configLoader;
        private Dictionary<TKey, T> _configDataDictionary;
        private readonly ILog _log;
        protected abstract string ConfigName { get; }
        protected abstract TKey GetId(T item);

        protected BaseConfigRepository(IConfigLoader configLoader,
            ILog log)
        {
            _log = log;
            _configLoader = configLoader;
        }

        public List<T> GetAll()
        {
            return _configDataDictionary.Values.ToList();
        }

        public T Get(TKey id)
        {
            _configDataDictionary.TryGetValue(id, out var result);
            return DeepCopy(result);
        }

        private TEntity DeepCopy<TEntity>(TEntity obj)
        {
            if (obj is string || obj.GetType().IsValueType) return obj;
            var retval = Activator.CreateInstance(obj.GetType());
            var fields = obj.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance |
                                                 BindingFlags.Static);
            foreach (var field in fields)
            {
                try
                {
                    field.SetValue(retval, DeepCopy(field.GetValue(obj)));
                }
                catch (Exception e)
                {
                    _log.Error($"BaseConfigRepository.DeepCopy Error:{e}");
                }
            }

            return (TEntity)retval;
        }

        public async Task Initialize()
        {
            var loadConfigData = await _configLoader.LoadConfigData<T>(ConfigName);
            _configDataDictionary = loadConfigData.ToDictionary(GetId);
        }
    }
}