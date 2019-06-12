using System;
using System.Linq;
using Xunit;

namespace Putn
{
    public class ShoppingServiceTests
    {
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
        public static object[][] CalculateTotalPayableTestCases = new object[][] 
        {
            // no item at all
            new object[] { new Item[]{}, 20, 0 },
            // single discountable
            new object[] 
            { 
                new Item[]{ new Item { IsDiscountable = true, Price = 100 } }, 
                20, 
                80
            },
            // add more test cases?
        };

        [Theory]
        [MemberData(nameof(CalculateTotalPayableTestCases))]
        public void CalculateTotalPayableTests(Item[] items, decimal discountToApply, decimal expectedTotal)
        {
            var actual = ShoppingService.CalculateTotalPayable(items, discountToApply);

            Assert.Equal(actual, expectedTotal);
        }
    }
}
