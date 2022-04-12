using System;

namespace SIMS.Model
{

    public class Address
    {

        public String Street { get; set; }
        public String Number { get; set; }

        public City City { get; set; }
        public Country Country { get; set; }

        public Address(string street, string number, City city, Country country)
        {
            Street = street;
            Number = number;
            City = city;
            Country = country;
        }

    }
}