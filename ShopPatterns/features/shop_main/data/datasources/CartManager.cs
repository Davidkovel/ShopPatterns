using System;
using System.Collections.Generic;
using ShopPatterns.core.enteties;

namespace ShopPatterns.features.cart.data.datasources
{
    public class CartManager // Вместо бд, umsetzen singleton
    {
        private static CartManager? _instance;
        private static object _lock = new object();

        public List<Product> Cart { get; private set; }
        public List<Product> availableProducts { get; private set; }

        public CartManager()
        {
            Cart = new List<Product>();

            availableProducts = new List<Product>
            {

                new Product(0, "Laptop Lenovo i5 slim", 2000),
                new Product(1, "Smartphone iphone 11", 400),
                new Product(2, "Headphones air podes", 700)

            };
        }


        public static CartManager getInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new CartManager();
                    }
                }
            }
            return _instance;
        }

        public void DisplayAvailableProducts()
        {
            foreach (var product in availableProducts)
            {
                Console.WriteLine(product);
            }

        }

        public void AddToCart()
        {
            try
            {
                DisplayAvailableProducts();
                int productId = ChooseProduct();

                Product? selectedProduct = availableProducts.Find(p => p.Id == productId);
                if (selectedProduct != null)
                {
                    Cart.Add(selectedProduct);
                    Console.WriteLine($"{selectedProduct.Name} added to cart!\n");

                    while (AskForAnotherProduct())
                    {
                        Product clonedProduct = (Product)selectedProduct.Clone();
                        Cart.Add(clonedProduct);
                        Console.WriteLine($"Cloned {clonedProduct.Name} added to cart!\n");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid product ID. Please try again.\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while adding to cart: {ex.Message}");
            }
        }

        private bool AskForAnotherProduct()
        {
            Console.Write("Would you like to add the same product again? (yes/no): ");
            string? response = Console.ReadLine()?.Trim().ToLower();
            return response == "yes" || response == "y";
        }


        private int ChooseProduct()
        {
            Console.Write("\nEnter the ID of the product you want to add: ");
            while (true)
            {
                try
                {
                    if (int.TryParse(Console.ReadLine(), out int id))
                    {
                        return id;
                    }
                    throw new FormatException("Invalid input. Please enter a valid product ID.");
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"{ex.Message}");
                    Console.Write("Try again: ");
                }
            }
        }

        public void DisplayCart()
        {
            Console.WriteLine("Your cart:");
            if (Cart.Count == 0)
            {
                Console.WriteLine("Cart is empty");
            }
            else
            {
                foreach (var product in Cart)
                {
                    Console.WriteLine(product);
                }
            }
        }

        public void ClearCart()
        {
            Cart.Clear();
        }
    }
}
