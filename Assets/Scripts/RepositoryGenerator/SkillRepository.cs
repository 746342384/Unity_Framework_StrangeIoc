using System;
using System.Collections.Generic;
using Framework.framework.log;
using Framework.framework.repository;
using Framework.framework.attribute;

namespace Repository.Skill
{

    public interface ISkillRepository : IReadOnlyRepository<int, Skill>
    {
    }

    [Repository(typeof(ISkillRepository))]
    public class SkillRepository : BaseConfigRepository<int, Skill>
    {
        public SkillRepository(IConfigLoader configLoader, ILog log) : base(configLoader, log) { }
        protected override string ConfigName => nameof(Skill);

        protected override int GetId(Skill item)
        {
            // Replace the property name 'Id' with the actual key property name of your entity class.
            return item.Id;
        }
    }
}