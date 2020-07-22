using System;
using NUnit.Framework;

namespace Putn
{
    public class CalculateDiscountTests
    {
        public static object[][] DiscountForPromoCodeTestCases = new object[][]
        {
            new object[] { "AM", DateTime.Parse("2019-06-19 12:15:00"), 0m },
            new object[] { "AM", DateTime.Parse("2019-06-19 11:15:00"), 8m },
            new object[] { "PM", DateTime.Parse("2019-06-19 12:15:00"), 6m },
            new object[] { "PM", DateTime.Parse("2019-06-19 11:15:00"), 0m },
        };

        [Theory]
        [TestCaseSource(nameof(DiscountForPromoCodeTestCases))]
        public void CalculateDiscountForPromoCodeTest(string promoCode, DateTime when, decimal expectedDiscount)
        {
            var actual = CalculateDiscount.ForPromoCode(promoCode, when);
            
            Assert.AreEqual(expectedDiscount, actual);
        }
    }
}
