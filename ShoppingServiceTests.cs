using System;
using System.Linq;
using Moq;
using Xunit;

namespace Putn
{
    public class ShoppingServiceTests
    {
        [Fact]
        public void If_no_items_Then_nothing_to_pay()
        {
            var items = Enumerable.Empty<Item>();
            var member = new Membership { ID = 1, Type = MemberType.Diamond };
            var save = Mock.Of<Action<int, decimal>>();

            ShoppingService.Buy(items, member, null, (l, m) => {}, _ => {}, save);

            Mock.Get(save).Verify(r => r(1, 0), Times.Once);
        }

        // [Fact]
        // public void If_item_is_discountable_And_member_is_diamond_And_promo_code_is_akaramba_Then_discount_by_10_percent()
        // {
        //     var items = new [] { new Item { IsDiscountable = true, Price = 10m } };
        //     var member = new Membership { ID = 1, Type = MemberType.Diamond };
        //     var promoCode = "akaramba";
        //     var accountRepo = Mock.Of<IAccountRepository>();
        //     var shoppingService = new ShoppingService(Mock.Of<ILoggingService>(), accountRepo, Mock.Of<IPurchaseRepository>());

        //     ShoppingService.Buy(items, member, promoCode);

        //     Mock.Get(accountRepo).Verify(r => r.Debit(1, 9m), Times.Once);
        // }
    }
}
