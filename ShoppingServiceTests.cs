using System;
using System.Linq;
using Moq;
using Xunit;

namespace Putn
{
    public class ShoppingServiceTests
    {
        [Fact]
        public void If_member_is_buying_nothing_Then_should_not_be_debitted()
        {
            var itemIDs = Enumerable.Empty<int>();
            var memberID = 12345;
            var member = new Membership { Birthday = DateTime.Now };

            var accountRepo = Mock.Of<IAccountRepository>();
            var itemRepo = Mock.Of<IItemRepository>(i => i.FindByIDs(itemIDs) == new Item[]{});
            var memberRepo = Mock.Of<IMemberRepository>(m => m.FindMember(memberID) == member);

            var shoppingService = new ShoppingService(Mock.Of<ILoggingService>(), 
                itemRepo,
                accountRepo, 
                memberRepo);

            shoppingService.Buy(itemIDs, memberID, null);

            Mock.Get(accountRepo).Verify(r => r.Debit(memberID, 0), Times.Once);
        }

        [Fact]
        public void If_item_is_discountable_And_member_is_having_birthday_And_promo_code_is_akaramba_Then_discount_by_10_percent()
        {
            // try write this test
        }
    }
}
