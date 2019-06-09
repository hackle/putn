using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;

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
            if (member == null)
                throw new MemberNotFoundException(memberID);

            var items = this.itemRepo.FindByIDs(itemIDs) ?? new Item[]{};

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
            throw new NotImplementedException();
        }

        public static decimal CalculateDiscountForMemberBirthday(Member member, DateTime when)
        {
            throw new NotImplementedException();
        }
    }
}

// // decide birthday discount
// var birthdayDiscountPercentage = 0;
// var isBirthday = member.Birthday.Month == when.Month && member.Birthday.Date == when.Date;
// if (isBirthday)
// {
//     birthdayDiscountPercentage = 50;
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
// var discountToApply = Math.Max(birthdayDiscountPercentage, promoDiscountPercentage);
// var totalPayable = items.Sum(item => {
//     if (item.IsDiscountable)
//         return item.Price * (100 - discountToApply) / 100;
//     else 
//         return item.Price;
// });
