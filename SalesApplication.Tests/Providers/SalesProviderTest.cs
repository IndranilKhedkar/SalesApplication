using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalesApplication.Enums;
using SalesApplication.Providers.Sales.Implementation;
using System;

namespace SalesApplication.Tests.Providers
{
    [TestClass]
    public class SalesProviderTest
    {
        [TestMethod]
        public void GetSales_For_RegularCustomerType_Returns_Sales()
        {
            /* Arrange */
            var salesProvider = new SalesProvider();

            /* Act */
            var sales = salesProvider.GetSales(CustomerType.Regular, 99.99m);

            /* Assert */
            Assert.IsNotNull(sales);
            Assert.AreEqual(typeof(Sales), sales.GetType());
        }

        [TestMethod]
        public void GetSales_For_PremiumCustomerType_Returns_Sales()
        {
            /* Arrange */
            var salesProvider = new SalesProvider();

            /* Act */
            var sales = salesProvider.GetSales(CustomerType.Premium, 999.99m);

            /* Assert */
            Assert.IsNotNull(sales);
            Assert.AreEqual(typeof(Sales), sales.GetType());
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void GetSales_For_InvalidCustomerType_Throws_NotImplementedException()
        {
            /* Arrange */
            var salesProvider = new SalesProvider();

            /* Act */
            var sales = salesProvider.GetSales((CustomerType)3, 999.99m);

            /* Assert */
            Assert.IsNotNull(sales);
            Assert.AreEqual(typeof(Sales), sales.GetType());
        }
    }
}
