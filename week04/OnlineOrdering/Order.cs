using System.Collections.Generic;
using System.Text;

namespace OnlineOrdering
{
    /// <summary>
    /// Represents an order containing products and a customer.
    /// </summary>
    public class Order
    {
        private Customer _customer;
        private List<Product> _products;

        public Customer Customer => _customer;

        public Order(Customer customer)
        {
            _customer = customer;
            _products = new List<Product>();
        }

        /// <summary>
        /// Adds a product to the order.
        /// </summary>
        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        /// <summary>
        /// Returns the total cost of the order including shipping.
        /// </summary>
        public double GetTotalPrice()
        {
            double total = 0;
            foreach (var product in _products)
            {
                total += product.GetTotalCost();
            }

            double shipping = _customer.LivesInUSA() ? 5 : 35;
            total += shipping;

            return total;
        }

        /// <summary>
        /// Returns a packing label with name and product ID of each product.
        /// </summary>
        public string GetPackingLabel()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Packing Label:");
            foreach (var product in _products)
            {
                sb.AppendLine($"{product.Name} (ID: {product.ProductId})");
            }
            return sb.ToString();
        }

        /// <summary>
        /// Returns a shipping label with customer name and full address.
        /// </summary>
        public string GetShippingLabel()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Shipping Label:");
            sb.AppendLine(_customer.Name);
            sb.AppendLine(_customer.Address.GetFullAddress());
            return sb.ToString();
        }
    }
}
