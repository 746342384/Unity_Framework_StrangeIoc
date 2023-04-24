using System;
using System.Collections.Generic;
using Framework.framework.log;
using Framework.framework.repository;
using Framework.framework.attribute;

namespace Repository.Enemy
{

    public interface IEnemyRepository : IReadOnlyRepository<int, Enemy>
    {
    }

    [Repository(typeof(IEnemyRepository))]
    public class EnemyRepository : BaseConfigRepository<int, Enemy>
    {
        public EnemyRepository(IConfigLoader configLoader, ILog log) : base(configLoader, log) { }
        protected override string ConfigName => nameof(Enemy);

        protected override int GetId(Enemy item)
        {
            // Replace the property name 'Id' with the actual key property name of your entity class.
            return item.Id;
        }
    }
}