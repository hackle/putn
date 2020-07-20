using System;
using System.Linq;
using NUnit.Framework;

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
                0m
            },
            // having birthday!
            new object[]
            {
                new Item[] { new Item { Price = 100, IsDiscountable = true }},
                new Member { Birthday = new DateTime(1983, 4, 2) },
                null,
                new DateTime(2019, 4, 2),
                50m
            },
        };
        public static object[][] CalculateTotalPayableTestCases = new object[][] 
        {
            // no item at all
            new object[] 
            { 
                new Item[]{}, 
                20m, 
                0m 
            },
            // single discountable
            new object[] 
            { 
                new Item[]{ new Item { IsDiscountable = true, Price = 100 } }, 
                20m, 
                80m
            },
            // add more test cases?
        };

        [Theory]
        [TestCaseSource(nameof(CalculateTotalPayableTestCases))]
        public void CalculateTotalPayableTests(Item[] items, decimal discountToApply, decimal expectedTotal)
        {
            var actual = ShoppingService.CalculateTotalPayable(items, discountToApply);

            Assert.AreEqual(expectedTotal, actual);
        }
    }
}
