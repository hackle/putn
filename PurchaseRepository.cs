using System;
using System.Collections.Generic;

namespace Putn
{

    public class PurchaseRepository : IPurchaseRepository
    {
        public void Save(IEnumerable<Purchase> purchases)
        {
            throw new InvalidOperationException($"{nameof(PurchaseRepository)} I.O. is nice but not for tests");
        }
    }
}