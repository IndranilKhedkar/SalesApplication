namespace SalesApplication.DiscountStrategy
{
    public interface IDiscountStrategy
    {
        decimal GetBillAmount(decimal purchaseAmount);
    }
}
