using Xunit;

namespace Putn
{
    public class ShoppingServiceTests
    {
        // Test cases must be of type object[][]
        public static object[][] CalculateTotalPayableTestCases = new object[][] 
        {
            // each test case must be of type object[]
            // data must match parameters of the test method (by number and by type), in this case:
            //  (Item[] items, decimal discountToApply, decimal expectedTotal)

            // test case: no item at all
            new object[] { new Item[]{}, 20, 0 }, 

            // test case: single discountable item
            new object[] 
            { 
                new Item[]{ new Item { IsDiscountable = true, Price = 100 } }, 
                20, 
                80
            },
            // try add more test cases to make the algorithm more robust!
        };

        [Theory]
        [MemberData(nameof(CalculateTotalPayableTestCases))]
        public void CalculateTotalPayableTest(Item[] items, decimal discountToApply, decimal expectedTotal)
        {
            var actual = ShoppingService.CalculateTotalPayable(items, discountToApply);

            Assert.Equal(expectedTotal, actual);
        }

        public static object[][] DiscountForPromoCodeTestCases = new object[][]
        {
            // create your test cases
        };

        [Theory]
        [MemberData(nameof(DiscountForPromoCodeTestCases))]
        public void CalculateDiscountForPromoCodeTest() // <-- add parameters for input and expected result
        {
            // write your test for ShoppingService.CalculateDiscountForPromoCode(promoCode, when);
            // try keep it 2 lines only!
        }
    }
}
