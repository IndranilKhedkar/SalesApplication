using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalesApplication.DiscountStrategy.Implementation;
using System;

namespace SalesApplication.Tests.DiscountStrategy
{
    [TestClass]
    public class PremiumCustomerDiscountStrategyTest
    {
        [DataTestMethod]
        [DataRow("4000", "3600")]
        [DataRow("8000", "7000")]
        [DataRow("12000", "10200")]
        [DataRow("20000", "15800")]
        public void GetBillAmount_For_DifferentPurchaseAmounts_Returns_ExpectedDiscountedBillAmount(string purchaseAmount, string expectedDiscountedBillAmount)
        {
            /* Arrange */
            var premiumCustomerDiscountStrategy = new PremiumCustomerDiscountStrategy();

            /* Act */
            var result = premiumCustomerDiscountStrategy.GetBillAmount(decimal.Parse(purchaseAmount));

            /* Assert */
            Assert.AreEqual(decimal.Parse(expectedDiscountedBillAmount), result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetBillAmount_For_PurchaseAmountLessThanZero_Throws_ArgumentException()
        {
            /* Arrange */
            decimal purchaseAmount = -99.99m;
            var regularCustomerDiscountStrategy = new PremiumCustomerDiscountStrategy();

            /* Act */
            _ = regularCustomerDiscountStrategy.GetBillAmount(purchaseAmount);
        }
    }
}
