namespace OnlineOrdering
{
    /// <summary>
    /// Represents a customer with a name and address.
    /// </summary>
    public class Customer
    {
        private string _name;
        private Address _address;

        public string Name => _name;
        public Address Address => _address;

        public Customer(string name, Address address)
        {
            _name = name;
            _address = address;
        }

        /// <summary>
        /// Returns true if the customer lives in the USA.
        /// </summary>
        public bool LivesInUSA()
        {
            return _address.IsInUSA();
        }
    }
}
