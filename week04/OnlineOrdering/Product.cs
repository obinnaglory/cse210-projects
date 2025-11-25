namespace OnlineOrdering
{
    /// <summary>
    /// Represents a product in an order.
    /// </summary>
    public class Product
    {
        private string _name;
        private string _productId;
        private double _price;
        private int _quantity;

        public string Name => _name;
        public string ProductId => _productId;
        public double Price => _price;
        public int Quantity => _quantity;

        public Product(string name, string productId, double price, int quantity)
        {
            _name = name;
            _productId = productId;
            _price = price;
            _quantity = quantity;
        }

        /// <summary>
        /// Returns the total cost of this product (price * quantity).
        /// </summary>
        public double GetTotalCost()
        {
            return _price * _quantity;
        }
    }
}
