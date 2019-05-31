using System.Collections.Generic;
using Xunit;

namespace Putn 
{
    public class MemberDiscountTests
    {
        [Theory]
        [MemberData(nameof(TestCases))]
        public void Discounts_are_different_per_member_type(MemberType memberType, decimal expectedDiscount)
        {
            var actual = MemberDiscount.GetInPercentage(new Membership { Type = memberType });

            Assert.Equal(expectedDiscount, actual);
        }

        public static IEnumerable<object[]> TestCases =
            new object[][] 
            {
                new object[] { MemberType.Diamond, 10m },
                new object[] { MemberType.Gold, 5m },
                new object[] { MemberType.MostValued, 0m },
            };
    }
}