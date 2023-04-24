using System;
using System.Collections.Generic;
using Framework.framework.log;
using Framework.framework.repository;
using Framework.framework.attribute;

namespace Repository.Player
{

    public interface IPlayerRepository : IReadOnlyRepository<int, Player>
    {
    }

    [Repository(typeof(IPlayerRepository))]
    public class PlayerRepository : BaseConfigRepository<int, Player>
    {
        public PlayerRepository(IConfigLoader configLoader, ILog log) : base(configLoader, log) { }
        protected override string ConfigName => nameof(Player);

        protected override int GetId(Player item)
        {
            // Replace the property name 'Id' with the actual key property name of your entity class.
            return item.Id;
        }
    }
}