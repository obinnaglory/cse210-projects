namespace OnlineOrdering
{
    /// <summary>
    /// Represents a customer's address.
    /// </summary>
    public class Address
    {
        private string _street;
        private string _city;
        private string _stateOrProvince;
        private string _country;

        public Address(string street, string city, string stateOrProvince, string country)
        {
            _street = street;
            _city = city;
            _stateOrProvince = stateOrProvince;
            _country = country;
        }

        /// <summary>
        /// Returns true if the address is in the USA.
        /// </summary>
        public bool IsInUSA()
        {
            return _country.ToUpper() == "USA" || _country.ToUpper() == "UNITED STATES";
        }

        /// <summary>
        /// Returns the full address as a string (multi-line).
        /// </summary>
        public string GetFullAddress()
        {
            return $"{_street}\n{_city}, {_stateOrProvince}\n{_country}";
        }
    }
}
