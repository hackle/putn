﻿using System.Linq;
using Moq;
using NUnit.Framework;

namespace Putn
{
    public class ShoppingServiceTests
    {
        public static object[][] CalculateTotalPayableTestCases = new object[][] 
        {
            // no item at all
            new object[] { new Item[]{}, 20m, 0m },
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
