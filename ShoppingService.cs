using System;
using System.Collections.Generic;
using System.Linq;

namespace Putn
{
    public class ShoppingService
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
            // decide member discount
            var memberDiscountPercentage = 0;
            switch (member.Type)
            {
                case MemberType.Diamond: 
                    memberDiscountPercentage = 10;
                    break;
                case MemberType.Gold:
                    memberDiscountPercentage = 5;
                    break;
                default: 
                    break;
            }

            // decide promo discount
            var promoDiscountPercentage = 0;
            if (promoCode == "akaramba")
            {
                promoDiscountPercentage = 8;
            }
            else if (promoCode == "excellent")
            {
                promoDiscountPercentage = 6;
            }

            // decide applicable discount and create purchases
            var discountToApply = Math.Max(memberDiscountPercentage, promoDiscountPercentage);
            var purchases = items.Select(item => {
                decimal purchasePrice;
                if (item.IsDiscountable)
                    purchasePrice = item.Price * (1.0m - discountToApply / 100);
                else 
                    purchasePrice = item.Price;

                return new Purchase { ItemID = item.ID, PurchasePrice = purchasePrice, MemberID = member.ID };
            });

            // log and persist
            this.loggingService.Log(LogLevel.Info, $"We got member {member.ID} hooked!");

            this.purchaseRepo.Save(purchases);
            this.accountRepo.Debit(member.ID, purchases.Sum(p => p.PurchasePrice));
        }
    }
}