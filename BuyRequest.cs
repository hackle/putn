using System.Collections.Generic;

namespace Putn
{
    public class BuyRequest
    {
        public IEnumerable<Item> Items { get; set; }

        public string PromoCode { get; set; }
    }
}