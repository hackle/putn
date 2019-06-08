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

        public static double CalculateTotalPayable(IEnumerable<Item> items, double discountToAppy)
        {
            throw new NotImplementedException();
        }

        public static int CalculateDiscountForPromoCode(string promoCode, DateTime when)
        {
            throw new NotImplementedException();
        }

        public static double CalculateDiscountForMemberBirthday(Member member, DateTime when)
        {
            throw new NotImplementedException();
        }
    }
}
