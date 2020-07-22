using System.Linq;
using Moq;
using NUnit.Framework;

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
            new object[] 
            { 
                new Item[]{}, 
                20m, 
                0m
            }, 

            // test case: single discountable item
            new object[] 
            { 
                new Item[]{ new Item { IsDiscountable = true, Price = 100 } }, 
                20m, 
                80m
            },
            // try add more test cases to make the algorithm more robust!
        };

        [Theory]
        [TestCaseSource(nameof(CalculateTotalPayableTestCases))]
        public void CalculateTotalPayableTest(Item[] items, decimal discountToApply, decimal expectedTotal)
        {
            var actual = ShoppingService.CalculateTotalPayable(items, discountToApply);

            Assert.AreEqual(expectedTotal, actual);
        }
    }
}
