using System.Collections.Generic;

namespace Putn
{
    public interface IPurchaseRepository
    {
        void Save(IEnumerable<Purchase> purchases);
    }
}