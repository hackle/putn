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
}