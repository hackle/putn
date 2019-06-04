using System.Collections.Generic;

namespace Putn
{
    public class BuyRequest
    {
        public IEnumerable<int> ItemIDs { get; set; }

        public string PromoCode { get; set; }
    }
}