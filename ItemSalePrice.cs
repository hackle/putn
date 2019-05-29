using System;

namespace Putn
{
    public static class ItemSalePrice
    {
        public static decimal Calculate(
            Item item, 
            decimal memberDiscountPercentage, 
            decimal promoDiscountPercentage)
        {
            var discountToApply = Math.Max(memberDiscountPercentage, promoDiscountPercentage);
            
            if (item.IsDiscountable)
                return item.Price * (1.0m - discountToApply / 100);
            else 
                return item.Price;
        }
    }
}