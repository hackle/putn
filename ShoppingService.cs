using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;

namespace Putn
{
    public static class ShoppingService
    {    
        public static void Checkout(
            string promoCode, 
            DateTime when,
            Func<Member> findMember,
            Func<IEnumerable<Item>> findItems,
            Action<decimal> chargeMember) 
        {
            var birthdayDiscount = CalculateDiscount.ForMemberBirthday(findMember(), when);
            var promoCodeDiscount = CalculateDiscount.ForPromoCode(promoCode, when);
            var discountToApply = Math.Max(birthdayDiscount, promoCodeDiscount);
            var totalPayable = CalculateTotalPayable(findItems(), discountToApply);

            chargeMember(totalPayable);
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
