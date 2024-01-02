namespace kayttoliittyma_harjoitustyo
{
    /// <summary>
    /// Customer class
    /// </summary>
    public class Customer
    {
        public int CustomerID { get; set; }
        public string? CustomerName { get; set; }

        public string? StreetAddress { get; set; }
        public int PostalCode { get; set; }
        public string? City { get; set; }


        public Customer()
        {
            CustomerID = 0;

        }
    }
}
