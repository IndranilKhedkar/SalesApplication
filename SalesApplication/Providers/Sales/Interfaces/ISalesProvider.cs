using SalesApplication.Enums;

namespace SalesApplication.Providers.Sales.Interfaces
{
    public interface ISalesProvider
    {
        public ISales GetSales(CustomerType customerType, decimal purchaseAmount);
    }
}
