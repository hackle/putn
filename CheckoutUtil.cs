using System;
using System.Collections.Generic;

namespace Putn
{
    internal class CheckoutUtil
    {// // decide birthday discount
     // var memberDiscountPercentage = 0;
     // var isBirthday = member.Birthday.Month == when.Month && member.Birthday.Date == when.Date;
     // if (isBirthday)
     // {
     //     memberDiscountPercentage = 50;
     // }

        // // decide promo discount
        // var promoDiscountPercentage = 0;
        // if (promoCode == "AM" && when.Hour < 12)
        // {
        //     promoDiscountPercentage = 8;
        // }
        // else if (promoCode == "PM" && when.Hour >= 12)
        // {
        //     promoDiscountPercentage = 6;
        // }

        // // decide applicable discount and create purchases
        // var discountToApply = Math.Max(memberDiscountPercentage, promoDiscountPercentage);
        // var totalPayable = items.Sum(item => {
        //     if (item.IsDiscountable)
        //         return item.Price * (100 - discountToApply) / 100;
        //     else 
        //         return item.Price;
        // });
        internal static double CalculateBirthdayDiscount(Member member, DateTime when)
        {
            throw new NotImplementedException();
        }

        internal static double CalculatePromoDiscount(Member member, DateTime when)
        {
            throw new NotImplementedException();
        }

        internal static double CalculateTotalPayable(IEnumerable<Item> items, object memberDiscountPercentage, object promoDiscountPercentage)
        {
            throw new NotImplementedException();
        }
    }
}