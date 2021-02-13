namespace Demo.Domain.Entities
{
    public class Address : Entity
    {
        public Address(string street, string number, string neighborhood, string city, string state, string country, string zipCode, int appUserId)
        {
            Street = street;
            Number = number;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipCode;
            AppUserId = appUserId;
        }

        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Neighborhood { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }
        public bool Main { get; private set; }        

        public int AppUserId { get; private set; }
        //public AppUser AppUsers { get; private set; }
    }
}
