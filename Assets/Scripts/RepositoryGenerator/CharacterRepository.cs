using System;
using System.Collections.Generic;
using Framework.framework.log;
using Framework.framework.repository;
using Framework.framework.attribute;

namespace Repository.Character
{

    public interface ICharacterRepository : IReadOnlyRepository<int, Character>
    {
    }

    [Repository(typeof(ICharacterRepository))]
    public class CharacterRepository : BaseConfigRepository<int, Character>
    {
        public CharacterRepository(IConfigLoader configLoader, ILog log) : base(configLoader, log) { }
        protected override string ConfigName => nameof(Character);

        protected override int GetId(Character item)
        {
            // Replace the property name 'Id' with the actual key property name of your entity class.
            return item.Id;
        }
    }
}