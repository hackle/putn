using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;

namespace Putn
{
    public static class ShoppingService
    {    
        public static void Checkout(IEnumerable<int> itemIDs, int memberID, string promoCode, DateTime when) 
        {
            var member = MemberRepository.FindByID(memberID);
            if (member == null)
                throw new MemberNotFoundException(memberID);
            var items = ItemRepository.FindByIDs(itemIDs) ?? new Item[]{};

            var birthdayDiscount = CalculateDiscount.ForMemberBirthday(member, when);
            var promoCodeDiscount = CalculateDiscount.ForPromoCode(promoCode, when);
            var discountToApply = Math.Max(birthdayDiscount, promoCodeDiscount);
            var totalPayable = CalculateTotalPayable(items, discountToApply);

            // log and persist
            LoggingService.Log(LogLevel.Info, $"We got member {member.Name} hooked!");
            PaymentService.Charge(memberID, totalPayable);
        }

        public static decimal CalculateTotalPayable(IEnumerable<Item> items, decimal discountToApply)
        {
            return items.Sum(item => {
                if (item.IsDiscountable)
                    return item.Price * (100 - discountToApply) / 100;
                else 
                    return item.Price;
            });
        }
    }
}
