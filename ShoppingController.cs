
namespace Putn
{
    public class ShoppingController
    {
        public void Buy(BuyRequest request)
        {
            var member = new Membership { Type = MemberType.Diamond };
            ShoppingService.Buy(request.Items, member, request.PromoCode);
        }
    }
}