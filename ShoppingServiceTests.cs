using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using Xunit;

namespace Putn
{
    public class ShoppingServiceTests
    {
        [Theory]
        [MemberData(nameof(TotalChargedTestCases))]
        public void Member_is_charged_per_discounts(
            IEnumerable<int> itemIDs,
            IEnumerable<Item> items,
            int memberID,
            Member member,
            string promoCode,
            DateTime checkoutTime,
            decimal expectedTotalCharged)
        {
            // Arrange
            var chargeMemberMock = new Mock<Action<int, decimal>>();

            // Act
            ShoppingService.Checkout(itemIDs, 
                memberID, 
                promoCode: null, 
                when: checkoutTime,
                findMemberByID: id => member,
                findItemsByIDs: ids => items,
                log: (level, msg) => {return;},
                chargeMember: chargeMemberMock.Object);

            // Assert
            chargeMemberMock.Verify(r => r(memberID, expectedTotalCharged), Times.Once);
        }

        public static object[][] TotalChargedTestCases = new object[][]
        {
            // buying nothing
            new object[]
            {
                new int[] {},
                new Item[] {},
                12345,
                new Member { Birthday = new DateTime(1983, 4, 2) },
                null,
                new DateTime(2019, 4, 1),
                0
            },
            // having birthday!
            new object[]
            {
                new int[] {},
                new Item[] { new Item { Price = 100, IsDiscountable = true }},
                12345,
                new Member { Birthday = new DateTime(1983, 4, 2) },
                null,
                new DateTime(2019, 4, 2),
                50
            },
        };
    }
}
