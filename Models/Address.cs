namespace MapTracker.Models
{
    public class Address
    {
        public string street1 { get; set; }
        public string street2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zipCode { get; set; }

        public override string ToString()
        {
            string availableAddress = string.Empty;

            if (!string.IsNullOrWhiteSpace(street1))
                availableAddress += street1 + " ";

            if (!string.IsNullOrWhiteSpace(street2))
                availableAddress += street2 + " ";

            if (!string.IsNullOrWhiteSpace(city))
                availableAddress += city + " ";

            if (!string.IsNullOrWhiteSpace(state))
                availableAddress += state + " ";

            if (!string.IsNullOrWhiteSpace(zipCode))
                availableAddress += zipCode;

            return availableAddress;
        }
    }
}