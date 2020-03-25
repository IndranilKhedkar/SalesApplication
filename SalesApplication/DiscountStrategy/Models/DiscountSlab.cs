namespace SalesApplication.DiscountStrategy.Models
{
    public class DiscountSlab
    {
        public decimal MinAmount { get; set; }
        public decimal MaxAmount { get; set; }
        public decimal DiscountRate { get; set; }
    }
}
