using System.Collections.Generic;

namespace Putn
{
    public interface IShoppingService
    {
        void Buy(IEnumerable<Item> items, Membership member, string promoCode);
    }
}