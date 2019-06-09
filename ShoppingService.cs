﻿using System;
using System.Collections.Generic;
using System.Linq;

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
            var member = findMember();
            var items = findItems();

            var birthdayDiscount = CalculateDiscountForMemberBirthday(member, when);
            var promoCodeDiscount = CalculateDiscountForPromoCode(promoCode, when);
            var discountToApply = Math.Max(birthdayDiscount, promoCodeDiscount);
            var totalPayable = CalculateTotalPayable(items, discountToApply);

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