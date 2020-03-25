using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalesApplication.DiscountStrategy.Implementation;
using System;

namespace SalesApplication.Tests.DiscountStrategy
{
    [TestClass]
    public class RegularCustomerDiscountStrategyTest
    {
        [DataTestMethod]
        [DataRow("5000", "5000")]
        [DataRow("10000", "9500")]
        [DataRow("15000", "13500")]
        public void GetBillAmount_For_DifferentPurchaseAmounts_Returns_ExpectedDiscountedBillAmount(string purchaseAmount, string expectedDiscountedBillAmount)
        {
            /* Arrange */
            var regularCustomerDiscountStrategy = new RegularCustomerDiscountStrategy();

            /* Act */
            var result = regularCustomerDiscountStrategy.GetBillAmount(decimal.Parse(purchaseAmount));

            /* Assert */
            Assert.AreEqual(decimal.Parse(expectedDiscountedBillAmount), result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetBillAmount_For_PurchaseAmountLessThanZero_Throws_ArgumentException()
        {
            /* Arrange */
            decimal purchaseAmount = -99.99m;
            var regularCustomerDiscountStrategy = new RegularCustomerDiscountStrategy();

            /* Act */
            _ = regularCustomerDiscountStrategy.GetBillAmount(purchaseAmount);
        }
    }
}
