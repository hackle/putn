using System;
using System.Collections.Generic;
using Moq;
using Xunit;

namespace Putn
{
    public class ShoppingServiceIntegrationTests
    {
        [Theory]
        [MemberData(nameof(TotalChargedTestCases))]
        public void Member_is_charged_per_discounts(
            IEnumerable<Item> items,
            Member member,
            string promoCode,
            DateTime checkoutTime,
            decimal expectedTotalCharged)
        {
            // Arrange
            var chargeMemberMock = new Mock<Action<decimal>>();

            // Act
            ShoppingService.Checkout(
                promoCode: promoCode, 
                when: checkoutTime,
                findMember: () => member,
                findItems: () => items,
                chargeMember: chargeMemberMock.Object);

            // Assert
            chargeMemberMock.Verify(r => r(expectedTotalCharged), Times.Once);
        }

        public static object[][] TotalChargedTestCases = new object[][]
        {
            // buying nothing
            new object[]
            {
                new Item[] {},
                new Member { Birthday = new DateTime(1983, 4, 2) },
                null,
                new DateTime(2019, 4, 1),
                0
            },
            // having birthday!
            new object[]
            {
                new Item[] { new Item { Price = 100, IsDiscountable = true }},
                new Member { Birthday = new DateTime(1983, 4, 2) },
                null,
                new DateTime(2019, 4, 2),
                50
            },
        };
    }
}
