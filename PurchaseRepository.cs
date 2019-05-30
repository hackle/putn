using System;
using System.Collections.Generic;

namespace Putn
{
    public interface IPurchaseRepository
    {
        void Save(IEnumerable<Purchase> purchases);
    }

    public class PurchaseRepository : IPurchaseRepository
    {
        public void Save(IEnumerable<Purchase> purchases)
        {
            Console.WriteLine("Nice buys! Now buy now!");
        }
    }
}