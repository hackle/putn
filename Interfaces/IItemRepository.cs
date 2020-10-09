using System.Collections.Generic;

namespace Putn
{
    public interface IItemRepository
    {
        IEnumerable<Item> FindByIDs(IEnumerable<int> itemIDs);
    }
}