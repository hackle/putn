using System;
using System.Linq;
using Moq;
using Xunit;

namespace Putn
{
    public class ShoppingServiceTests
    {
        [Fact]
        public void If_member_is_buying_nothing_Then_should_not_be_charged()
        {
            // Arrange
            var itemIDs = Enumerable.Empty<int>();
            var memberID = 12345;
            var member = new Member { Birthday = DateTime.Now };

            var loggingServiceMock = new Mock<ILoggingService>();
            var accountRepoMock = new Mock<IPaymentService>();

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
            accountRepoMock.Verify(r => r.Charge(memberID, 0), Times.Once);
        }

        [Fact]
        public void If_item_is_not_discountable_Although_member_is_having_birthday_Then_should_not_be_charged_fully()
        {
            // Arrange
            var itemIDs = new int[]{ 11, 22 };
            var items = new Item[] 
            { 
                new Item { Name = "foo", Price = 50 },
                new Item { Name = "bar", Price = 100 },
            };
            var memberID = 12345;
            var member = new Member { Birthday = DateTime.Now };

            var loggingServiceMock = new Mock<ILoggingService>();
            var accountRepoMock = new Mock<IPaymentService>();

            var itemRepoMock = new Mock<IItemRepository>();
            itemRepoMock.Setup(i => i.FindByIDs(itemIDs)).Returns(items);

            var memberRepoMock = new Mock<IMemberRepository>();
            memberRepoMock.Setup(m => m.FindByID(memberID)).Returns(member);

            var shoppingService = new ShoppingService(loggingServiceMock.Object, 
                itemRepoMock.Object,
                accountRepoMock.Object, 
                memberRepoMock.Object);

            // Act
            shoppingService.Buy(itemIDs, memberID, promoCode: null, when: DateTime.Now);

            // Assert
            accountRepoMock.Verify(r => r.Charge(memberID, 150), Times.Once);
        }

        [Fact]
        public void If_item_is_discountable_And_member_is_having_birthday_And_Then_discount_by_50_percent()
        {
            // try write this test
        }

        [Fact]
        public void If_item_is_discountable_And_member_is_having_birthday_And_promo_code_is_akaramba_Then_discount_by_50_percent()
        {
            // try write this test
        }

        [Fact]
        public void If_item_is_discountable_And_member_is_not_having_birthday_And_promo_code_is_akaramba_Then_discount_by_10_percent()
        {
            // try write this test
        }
    }
}
