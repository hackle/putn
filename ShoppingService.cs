using System;
using System.Collections.Generic;
using System.Linq;

namespace Putn
{
    public static class ShoppingService
    {    
        public static void Checkout(IEnumerable<int> itemIDs, int memberID, string promoCode, DateTime when) 
        {
            var member = MemberRepository.FindByID(memberID);
            var items = ItemRepository.FindByIDs(itemIDs);

            var birthdayDiscount = CalculateDiscountForMemberBirthday(member, when);
            var promoCodeDiscount = CalculateDiscountForPromoCode(promoCode, when);
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

        public static int CalculateDiscountForPromoCode(string promoCode, DateTime when)
        {
            if (promoCode == "AM" && when.Hour < 12)
            {
                return 8;
            }
            else if (promoCode == "PM" && when.Hour >= 12)
            {
                return 6;
            }

            return 0;
        }

        public static decimal CalculateDiscountForMemberBirthday(Member member, DateTime when)
        {
            var isBirthday = member.Birthday.Month == when.Month && member.Birthday.Date == when.Date;
            return isBirthday ? 50 : 0;
        }
    }
}