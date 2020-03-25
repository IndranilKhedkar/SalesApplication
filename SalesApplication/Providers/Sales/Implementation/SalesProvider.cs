using SalesApplication.DiscountStrategy.Implementation;
using SalesApplication.Enums;
using SalesApplication.Providers.Sales.Interfaces;
using System;

namespace SalesApplication.Providers.Sales.Implementation
{
    public class SalesProvider : ISalesProvider
    {
        public ISales GetSales(CustomerType customerType, decimal purchaseAmount)
        {
            return customerType switch
            {
                CustomerType.Regular => new Sales(purchaseAmount, new RegularCustomerDiscountStrategy()),
                CustomerType.Premium => new Sales(purchaseAmount, new PremiumCustomerDiscountStrategy()),
                _ => throw new NotImplementedException(),
            };
        }
    }
}
