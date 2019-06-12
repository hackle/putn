using System;
using System.Linq;
using Xunit;

namespace Putn
{
    public class ShoppingServiceTests
    {
        public static object[][] CalculateTotalPayableTestCases = 
        new object[][]
        {
            // no item at all
            new object[] 
            {(
                items: new Item[]{}, 
                discountToApply: 20m, 
                expectedTotal: 0m
            )},
            // single discountable
            new object[]
            {(
                items: new Item[]{ new Item { IsDiscountable = true, Price = 100 } }, 
                discountToApply: 20m, 
                expectedTotal: 80m
            )}
            // add more test cases?
        };

        [Theory]
        [MemberData(nameof(CalculateTotalPayableTestCases))]
        public void CalculateTotalPayableTests_WithTuple(
            (Item[] items, decimal discountToApply, decimal expectedTotal) testcase)
        {
            var actual = ShoppingService.CalculateTotalPayable(testcase.items, testcase.discountToApply);

            Assert.Equal(testcase.expectedTotal, actual);
        }


        [Fact]
        public void CalculateTotalPayableTests_Nested()
        {
            var testcases = new []
            {
                new  
                {
                    items = new Item[]{}, 
                    discountToApply = 20m, 
                    expectedTotal = 0m
                },
                new 
                {
                    items = new Item[]{ new Item { IsDiscountable = true, Price = 100 } }, 
                    discountToApply = 20m, 
                    expectedTotal = 80m
                }
            };

            foreach (var testcase in testcases)
            {
                var actual = ShoppingService.CalculateTotalPayable(testcase.items, testcase.discountToApply);

                Assert.Equal(testcase.expectedTotal, actual);
            }
        }
    }
}
