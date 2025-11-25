using System;

namespace OnlineOrdering
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create first customer
            Address address1 = new Address("123 Main St", "Springfield", "IL", "USA");
            Customer customer1 = new Customer("Alice Johnson", address1);

            // Create first order
            Order order1 = new Order(customer1);
            order1.AddProduct(new Product("Laptop", "LAP123", 1200, 1));
            order1.AddProduct(new Product("Mouse", "MOU456", 25, 2));
            order1.AddProduct(new Product("Keyboard", "KEY789", 45, 1));

            // Create second customer
            Address address2 = new Address("456 Elm St", "Toronto", "ON", "Canada");
            Customer customer2 = new Customer("Bob Smith", address2);

            // Create second order
            Order order2 = new Order(customer2);
            order2.AddProduct(new Product("Monitor", "MON101", 200, 2));
            order2.AddProduct(new Product("USB Cable", "USB202", 10, 5));

            // Display orders
            Order[] orders = { order1, order2 };
            foreach (var order in orders)
            {
                Console.WriteLine(order.GetPackingLabel());
                Console.WriteLine(order.GetShippingLabel());
                Console.WriteLine($"Total Price: ${order.GetTotalPrice():0.00}");
                Console.WriteLine(new string('-', 40));
            }
        }
    }
}
