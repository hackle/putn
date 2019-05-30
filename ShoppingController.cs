namespace Putn
{
    public class ShoppingController
    {
        private readonly ShoppingService shoppingService;

        public ShoppingController(ShoppingService shoppingService)
        {
            this.shoppingService = shoppingService;
        }

        public void Buy(BuyRequest request)
        {
            var member = new Membership { Type = MemberType.Diamond };
            this.shoppingService.Buy(request.Items, member, request.PromoCode);
        }
    }
}