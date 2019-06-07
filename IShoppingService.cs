using System;
using System.Collections.Generic;

namespace Putn
{
    public interface IShoppingService
    {
        void Buy(IEnumerable<int> itemIDs, int memberID, string promoCode, DateTime when);
    }
}