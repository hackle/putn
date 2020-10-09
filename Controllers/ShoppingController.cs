using System;

namespace Putn
{
    public class ShoppingController
    {
        private readonly IShoppingService shoppingService;

        public ShoppingController(IShoppingService shoppingService)
        {
            this.shoppingService = shoppingService;
        }

        public void Checkout(BuyRequest request)
        {
            this.shoppingService.Checkout(request.ItemIDs, ContextualMemberID, request.PromoCode, DateTime.Now);
        }

        private int ContextualMemberID = 20190620;
    }
}