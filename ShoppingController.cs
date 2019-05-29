using System;
using System.Collections.Generic;
using System.Linq;

namespace Putn
{
    public class ShoppingController
    {
        private ILoggingService loggingService;

        public ShoppingController(ILoggingService loggingService)
        {
            this.loggingService = loggingService;
        }

        public decimal CalculateTotalPayable(IEnumerable<Item> items, Membership member, string promoCode) 
        {
            var memberDiscountPercentage = MemberDiscount.GetInPercentage(member);
            var promoDiscountPercentage = PromoCodeDiscount.GetInPercentage(promoCode);

            var totalPayable = items.Sum(item => ItemSalePrice.Calculate(item, memberDiscountPercentage, promoDiscountPercentage));

            this.loggingService.Log(LogLevel.Info, $"logging that member XYZ gets prices for ABC with dicount so and so");

            return totalPayable;
        }
    }

    public static class MemberDiscount 
    {
        public static int GetInPercentage(Membership member)
        {
            switch (member.Type)
            {
                case MemberType.Diamond: return 10;
                case MemberType.Gold: return 5;
                default: return 0;
            }
        }
    }
    public static class PromoCodeDiscount
    {
        public static int GetInPercentage(string promoCode)
        {        
            if (promoCode == "akaramba")
            {
                return 8;
            }
            else if (promoCode == "excellent")
            {
                return 6;
            }

            return 0;
        }
    }

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