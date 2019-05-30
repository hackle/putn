using System;
using System.Collections.Generic;

namespace Putn
{
    public static class PurchaseRepository
    {
        public static void Save(IEnumerable<Purchase> purchases)
        {
            Console.WriteLine("Nice buys! Now buy now!");
        }
    }
}