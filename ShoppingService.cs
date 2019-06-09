using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;

namespace Putn
{
    public static class ShoppingService
    {    
        public static void Checkout(IEnumerable<int> itemIDs, 
            int memberID, 
            string promoCode, 
            DateTime when,
            Func<int, Member> findMemberByID,
            Func<IEnumerable<int>, IEnumerable<Item>> findItemsByIDs,
            Action<LogLevel, string> log,
            Action<int, decimal> chargeMember) 
        {
            var member = findMemberByID(memberID);
            if (member == null)
                throw new MemberNotFoundException(memberID);
            var items = findItemsByIDs(itemIDs) ?? new Item[]{};

            var birthdayDiscount = CalculateDiscountForMemberBirthday(member, when);
            var promoCodeDiscount = CalculateDiscountForPromoCode(promoCode, when);
            var discountToApply = Math.Max(birthdayDiscount, promoCodeDiscount);
            var totalPayable = CalculateTotalPayable(items, discountToApply);

            log(LogLevel.Info, $"We got member {member.Name} hooked!");
            chargeMember(memberID, totalPayable);
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