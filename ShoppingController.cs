using System;

namespace Putn
{
    public class ShoppingController
    {
        public void Checkout(BuyRequest request)
        {
            ShoppingService.Checkout(
                request.PromoCode, 
                DateTime.Now,
                () => MemberRepository.FindByID(ContextualMemberID),
                () => ItemRepository.FindByIDs(request.ItemIDs),
                total => {
                    LoggingService.Log(LogLevel.Info, $"Member {ContextualMemberID} charged {total}");
                    PaymentService.Charge(ContextualMemberID, total);
                });
        }

        private int ContextualMemberID = 20190620;
    }
}