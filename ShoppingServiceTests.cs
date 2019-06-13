using System;
using System.Collections.Generic;
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
                    Description = "No items",
                    Items = new Item[]{}, 
                    DiscountToApply = 20m, 
                    ExpectedTotal = 0m
                },
                new 
                {
                    Description = "Discountable item and 20% discount",
                    Items = new Item[]{ new Item { IsDiscountable = true, Price = 100 } }, 
                    DiscountToApply = 20m, 
                    ExpectedTotal = 80m
                }
            };

            foreach (var testcase in testcases)
            {
                var actual = ShoppingService.CalculateTotalPayable(testcase.Items, testcase.DiscountToApply);

                Assert.Equal(testcase.ExpectedTotal, actual);
            }
        }

        public class CalculateTotalTestCase
        {
            public string Description { get; set; }
            public IEnumerable<Item> Items { get; set; }
            public decimal DiscountToApply { get; set; }
            public decimal ExpectedTotal { get; set; }
        }

        [Theory]
        [MemberData(nameof(CalculateTotalTestCases))]
        public void CalculateTotalPayableTests_WithType(CalculateTotalTestCase testcase)
        {
            var actual = ShoppingService.CalculateTotalPayable(testcase.Items, testcase.DiscountToApply);

            Assert.Equal(testcase.ExpectedTotal, actual);
        }

        public static object[][] CalculateTotalTestCases =
            new object[][]
            {
                new object[]
                {
                    new CalculateTotalTestCase
                    {
                        Description = "No items",
                        Items = new Item[]{},
                        DiscountToApply = 20,
                        ExpectedTotal = 0
                    },
                },
                new object[]
                {
                    new CalculateTotalTestCase
                    {
                        Description = "Discountable item and 20% discount",
                        Items = new Item[]{ new Item { IsDiscountable = true, Price = 100 } }, 
                        DiscountToApply = 20m, 
                        ExpectedTotal = 80m
                    },
                },
            };
    }
}
