using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SalesApplication.DiscountStrategy;
using SalesApplication.Providers.Sales.Implementation;
using System;

namespace SalesApplication.Tests.Providers
{
    [TestClass]
    public class SalesTest
    {
        private Mock<IDiscountStrategy> _mockDiscountStrategy;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockDiscountStrategy = new Mock<IDiscountStrategy>();
        }

        [TestMethod]
        public void GetBillAmount_Returns_BillAmountReturnedByTheDiscountStrategy()
        {
            /* Arrange */
            _mockDiscountStrategy
                .Setup(d => d.GetBillAmount(It.IsAny<decimal>()))
                .Returns(99.99m);

            var sales = new Sales(99.99m, _mockDiscountStrategy.Object);

            /* Act */
            var billAmount = sales.GetBillAmount();

            /* Assert */
            Assert.IsNotNull(sales);
            Assert.AreEqual(99.99m, billAmount);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetBillAmount_For_GetBillAmountThrowingException_Throws_ExpectedException()
        {
            /* Arrange */
            _mockDiscountStrategy
                .Setup(d => d.GetBillAmount(-99.99m))
                .Throws(new ArgumentException());

            var sales = new Sales(-99.99m, _mockDiscountStrategy.Object);

            /* Act */
            _ = sales.GetBillAmount();
        }
    }
}
