using System;
using System.Collections.Generic;

namespace Putn
{
    public class ItemRepository : IItemRepository
    {
        public IEnumerable<Item> FindByIDs(IEnumerable<int> itemIDs)
        {
            throw new InvalidOperationException($"{nameof(ItemRepository)} I.O. is nice but not for tests");
        }
    }
}