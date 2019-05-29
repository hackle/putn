using System;
using System.Linq;
using Moq;
using Xunit;

namespace Putn
{
    public class ShoppingControllerTests
    {
        [Fact]
        public void If_no_items_Then_nothing_to_pay()
        {
            var items = Enumerable.Empty<Item>();
            var member = new Membership { Type = MemberType.Diamond };
            var shoppingController = new ShoppingController(Mock.Of<ILoggingService>());

            var actual = shoppingController.CalculateTotalPayable(items, member, null);

            Assert.Equal(0, actual);
        }

        [Fact]
        public void If_item_is_discountable_And_member_is_diamond_And_promo_code_is_akaramba_Then_discount_by_10_percent()
        {
            var items = new [] { new Item { IsDiscountable = true, Price = 10m } };
            var member = new Membership { Type = MemberType.Diamond };
            var promoCode = "akaramba";
            var shoppingController = new ShoppingController(Mock.Of<ILoggingService>());

            var actual = shoppingController.CalculateTotalPayable(items, member, promoCode);

            Assert.Equal(9, actual);
        }
    }
}
