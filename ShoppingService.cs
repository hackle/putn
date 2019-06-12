using System;
using System.Collections.Generic;
using System.Linq;

namespace Putn
{
    public class ShoppingService : IShoppingService
    {
        private readonly ILoggingService loggingService;
        private readonly IItemRepository itemRepo;
        private readonly IPaymentService paymentService;
        private readonly IMemberRepository memberRepo;

        public ShoppingService(ILoggingService loggingService, 
            IItemRepository itemRepo,
            IPaymentService paymentService,
            IMemberRepository memberRepo)
        {
            this.loggingService = loggingService;
            this.itemRepo = itemRepo;
            this.paymentService = paymentService;
            this.memberRepo = memberRepo;
        }

        public void Checkout(IEnumerable<int> itemIDs, int memberID, string promoCode, DateTime when) 
        {
            var member = this.memberRepo.FindByID(memberID);
            var items = this.itemRepo.FindByIDs(itemIDs);

            var birthdayDiscount = CalculateDiscountForMemberBirthday(member, when);
            var promoCodeDiscount = CalculateDiscountForPromoCode(promoCode, when);
            var discountToApply = Math.Max(birthdayDiscount, promoCodeDiscount);
            var totalPayable = CalculateTotalPayable(items, discountToApply);

            // log and persist
            this.loggingService.Log(LogLevel.Info, $"We got member {member.Name} hooked!");
            this.paymentService.Charge(memberID, totalPayable);
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
            var isBirthday = member.Birthday.Month == when.Month && member.Birthday.Day == when.Day;
            return isBirthday ? 50 : 0;
        }
    }
}
