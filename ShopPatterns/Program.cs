using System;
using ShopPatterns.core.enteties;
using ShopPatterns.features.cart.data.datasources;
using ShopPatterns.features.shop_main.domain.usecases.Builder;
using ShopPatterns.features.shop_main.domain.usecases.Director;
namespace ShopPatterns
{
    internal class Program
    {
        /*static Product productController()
        {
            /*Console.WriteLine("Enter the name of product:");
            string name = Console.ReadLine() ?? "Unnamed Product";

            Console.WriteLine("Enter the price of product:");
            double price = double.Parse(Console.ReadLine());

            return new Product(0, name, price);
        }*/

        static void Main(string[] args)
        {
            var cartManager = CartManager.getInstance();

            var orderFillBuilder = new OrderBuilder(cartManager);
            var director = new Director(orderFillBuilder);

            while (true)
            {
                Console.WriteLine("1. Add Product to cart");
                Console.WriteLine("2. View Cart");
                Console.WriteLine("3. Create Order");
                Console.WriteLine("0. Exit");
                Console.Write("Choose an option: ");

                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        // Product product = productController();
                        cartManager.AddToCart();
                        break;
                    case "2":
                        cartManager.DisplayCart();
                        break;
                    case "3":
                        director.fillMinimalInformationForOffer();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }
        }
    }
}
