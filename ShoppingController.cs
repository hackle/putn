using System;

namespace Putn
{
    public class ShoppingController
    {
        public void Checkout(BuyRequest request)
        {
            ShoppingService.Checkout(request.ItemIDs, 
                ContextualMemberID, 
                request.PromoCode, 
                DateTime.Now,
                MemberRepository.FindByID,
                ItemRepository.FindByIDs,
                LoggingService.Log,
                PaymentService.Charge);
        }

        private int ContextualMemberID = 20190620;
    }
}