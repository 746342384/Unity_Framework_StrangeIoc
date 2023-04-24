using Framework.framework.attribute;
using Framework.framework.log;
using Framework.framework.repository;

namespace Repository.Item
{
    public interface IItemRepository : IReadOnlyRepository<int, Item>
    {
    }

    [Repository(typeof(IItemRepository))]
    public class ItemRepository : BaseConfigRepository<int, Item>, IItemRepository
    {
        public ItemRepository(IConfigLoader configLoader, ILog log) : base(configLoader, log)
        {
        }

        protected override string ConfigName => nameof(Item);

        protected override int GetId(Item item)
        {
            // Replace the property name 'Id' with the actual key property name of your entity class.
            return item.Id;
        }
    }
}