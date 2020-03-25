using Microsoft.Extensions.DependencyInjection;
using SalesApplication.Enums;
using SalesApplication.Providers.Sales.Implementation;
using SalesApplication.Providers.Sales.Interfaces;
using System;
using System.Globalization;

namespace SalesApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Starting Sales Application{Environment.NewLine}");

            var serviceProvider = new ServiceCollection()
                .AddScoped<ISalesProvider, SalesProvider>()
                .BuildServiceProvider();

            InitiateSale(serviceProvider);

            Console.WriteLine("Thank you!");
        }

        private static void InitiateSale(ServiceProvider serviceProvider)
        {
            var salesProvider = serviceProvider.GetService<ISalesProvider>();

            string calculateShoppingBillAmount;
            do
            {
                Console.WriteLine("Customer Types: 1. Regular 2. Premium");
                Console.Write("Please select one (1 or 2): ");
                CustomerType customerType = (CustomerType)Enum.Parse(typeof(CustomerType), Console.ReadLine());

                Console.Write($"{Environment.NewLine}Enter the purchase amount: ");
                var purchaseAmount = decimal.Parse(Console.ReadLine());

                var sales = salesProvider.GetSales(customerType, purchaseAmount);
                var billAmount = sales.GetBillAmount();

                Console.WriteLine($"{Environment.NewLine}The final bill amount={billAmount.ToString("C", CultureInfo.CurrentCulture)}");

                Console.Write($"{Environment.NewLine}Do you want me to calculate shopping card bill amount again? Yes (y) or No (n): ");
                calculateShoppingBillAmount = Console.ReadLine()?.ToLower();

                Console.WriteLine();

                if (calculateShoppingBillAmount == "n")
                {
                    break;
                }
            } while (true);
        }
    }
}
