using System;
using System.Collections.Generic;
using System.Linq;

namespace Putn
{
    public class ShoppingService : IShoppingService
    {
        private readonly ILoggingService loggingService;
        private readonly IItemRepository itemRepo;
        private readonly IAccountRepository accountRepo;
        private readonly IMemberRepository memberRepo;

        public ShoppingService(ILoggingService loggingService, 
            IItemRepository itemRepo,
            IAccountRepository accountRepo,
            IMemberRepository memberRepo)
        {
            this.loggingService = loggingService;
            this.itemRepo = itemRepo;
            this.accountRepo = accountRepo;
            this.memberRepo = memberRepo;
        }

        public void Buy(IEnumerable<int> itemIDs, int memberID, string promoCode) 
        {
            var member = this.memberRepo.FindMember(memberID);
            var items = this.itemRepo.FindByIDs(itemIDs);

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
            if (member.Birthday.Month == DateTime.Now.Month &&
                member.Birthday.Date == DateTime.Now.Date)
                memberDiscountPercentage = 50;

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
            var totalPayable = items.Sum(item => {
                if (item.IsDiscountable)
                    return item.Price * (100 - discountToApply) / 100;
                else 
                    return item.Price;
            });

            // log and persist
            this.loggingService.Log(LogLevel.Info, $"We got member {member.ID} hooked!");

            this.accountRepo.Debit(member.ID, totalPayable);
        }
    }
}