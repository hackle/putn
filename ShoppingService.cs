using System;
using System.Collections.Generic;
using System.Linq;

namespace Putn
{
    public class ShoppingService : IShoppingService
    {
        private readonly ILoggingService loggingService;
        private readonly IAccountRepository accountRepo;
        private readonly IPurchaseRepository purchaseRepo;

        public ShoppingService(ILoggingService loggingService, 
            IAccountRepository accountRepo,
            IPurchaseRepository purchaseRepo)
        {
            this.loggingService = loggingService;
            this.accountRepo = accountRepo;
            this.purchaseRepo = purchaseRepo;
        }

        public void Buy(IEnumerable<Item> items, Membership member, string promoCode) 
        {
            var memberDiscountPercentage = MemberDiscount.GetInPercentage(member);
            var promoDiscountPercentage = PromoCodeDiscount.GetInPercentage(promoCode);
            var purchases = items.Select(item => new Purchase { 
                ItemID = item.ID, 
                MemberID = member.ID , 
                PurchasePrice = ItemSalePrice.Calculate(item, memberDiscountPercentage, promoDiscountPercentage)
            });

            this.loggingService.Log(LogLevel.Info, $"We got member {member.ID} hooked!");

            this.purchaseRepo.Save(purchases);
            this.accountRepo.Debit(member.ID, purchases.Sum(p => p.PurchasePrice));
        }
    }
}