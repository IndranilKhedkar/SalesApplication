using SalesApplication.DiscountStrategy;
using SalesApplication.Providers.Sales.Interfaces;

namespace SalesApplication.Providers.Sales.Implementation
{
    public class Sales : ISales
    {
        private readonly IDiscountStrategy _discountStrategy;
        private readonly decimal _purchaseAmount;

        public Sales(decimal purchaseAmount, IDiscountStrategy discountStrategy)
        {
            _purchaseAmount = purchaseAmount;
            _discountStrategy = discountStrategy;
        }

        public decimal GetBillAmount()
        {
            return _discountStrategy.GetBillAmount(_purchaseAmount);
        }
    }
}
