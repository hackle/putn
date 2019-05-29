using System;
using System.Collections.Generic;
using System.Linq;

namespace Putn
{
    public class ShoppingController
    {
        public decimal CalculateTotalPayable(IEnumerable<Item> items, 
            Membership member, 
            string promoCode,
            Action<LogLevel, string> log) 
        {
            var memberDiscountPercentage = MemberDiscount.GetInPercentage(member);
            var promoDiscountPercentage = PromoCodeDiscount.GetInPercentage(promoCode);

            var totalPayable = items.Sum(item => ItemSalePrice.Calculate(item, memberDiscountPercentage, promoDiscountPercentage));

            log(LogLevel.Info, $"logging that member XYZ gets prices for ABC with dicount so and so");

            return totalPayable;
        }
    }
}