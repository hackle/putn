using Xunit;

namespace Putn
{
    public class ShoppingServiceTests
    {
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
