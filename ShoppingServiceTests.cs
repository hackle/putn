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
            // Arrange
            var itemIDs = Enumerable.Empty<int>();
            var memberID = 12345;
            var member = new Membership { Birthday = DateTime.Now };

            var loggingServiceMock = new Mock<ILoggingService>();
            var accountRepoMock = new Mock<IAccountRepository>();

            var itemRepoMock = new Mock<IItemRepository>();
            itemRepoMock.Setup(i => i.FindByIDs(itemIDs)).Returns(new Item[]{});

            var memberRepoMock = new Mock<IMemberRepository>();
            memberRepoMock.Setup(m => m.FindByID(memberID)).Returns(member);

            var shoppingService = new ShoppingService(loggingServiceMock.Object, 
                itemRepoMock.Object,
                accountRepoMock.Object, 
                memberRepoMock.Object);

            // Act
            shoppingService.Buy(itemIDs, memberID, promoCode: null, when: DateTime.Now);

            // Assert
            accountRepoMock.Verify(r => r.Debit(memberID, 0), Times.Once);
        }

        [Fact]
        public void If_item_is_discountable_And_member_is_having_birthday_And_promo_code_is_akaramba_Then_discount_by_10_percent()
        {
            // try write this test
        }
    }
}
