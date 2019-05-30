using System;
using System.Collections.Generic;
using System.Linq;

namespace Putn
{
    public class ShoppingService
    {
        public static void Buy(IEnumerable<Item> items, Membership member, string promoCode) 
        {
            var memberDiscountPercentage = MemberDiscount.GetInPercentage(member);
            var promoDiscountPercentage = PromoCodeDiscount.GetInPercentage(promoCode);
            var purchases = items.Select(item => new Purchase { 
                ItemID = item.ID, 
                MemberID = member.ID , 
                PurchasePrice = ItemSalePrice.Calculate(item, memberDiscountPercentage, promoDiscountPercentage)
            });

            LoggingService.Log(LogLevel.Info, $"We got member {member.ID} hooked!");

            PurchaseRepository.Save(purchases);
            AccountRepository.Debit(member.ID, purchases.Sum(p => p.PurchasePrice));
        }
    }
}