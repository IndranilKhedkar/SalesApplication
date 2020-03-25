using SalesApplication.DiscountStrategy.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesApplication.DiscountStrategy.Implementation
{
    public class RegularCustomerDiscountStrategy : IDiscountStrategy
    {
        public decimal GetBillAmount(decimal purchaseAmount)
        {
            if (purchaseAmount < 0)
            {
                throw new ArgumentException($"${nameof(purchaseAmount)} can not be less than 0");
            }

            var discount = _discountSlabs
                .Where(d => d.MinAmount <= purchaseAmount)
                .Sum(x => (x.MinAmount <= purchaseAmount && x.MaxAmount > purchaseAmount)
                    ? ((purchaseAmount - x.MinAmount) * x.DiscountRate)
                    : ((x.MaxAmount - x.MinAmount) * x.DiscountRate));

            return (purchaseAmount - discount);
        }

        private static readonly List<DiscountSlab> _discountSlabs = new List<DiscountSlab>()
        {
            new DiscountSlab(){ MinAmount = 0, MaxAmount = 5000, DiscountRate = 0.0m },
            new DiscountSlab(){ MinAmount = 5000, MaxAmount = 10000, DiscountRate = 0.10m },
            new DiscountSlab(){ MinAmount = 10000, MaxAmount = decimal.MaxValue, DiscountRate = 0.20m }
        };
    }
}
