using SIMS.Model;
using SIMS.Service;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SIMS.Model
{

    public class Address : ValidationBase
    {

        public String street;
        public String number;

        public City city { get; set; }
        public Country Country { get; set; }

        public string Street
        {
            get { return street; }
            set
            {
                if (street != value)
                {
                    street = value;
                    OnPropertyChanged("Street");
                }
            }
        }
        public City City
        {
            get { return city; }
            set
            {
                if (city != value)
                {
                    city = value;
                    OnPropertyChanged("city");
                }
            }
        }
        public string Number
        {
            get { return number; }
            set
            {
                if (number != value)
                {
                    number = value;
                    OnPropertyChanged("Number");
                }
            }
        }

        public Address(string street, string number, City city, Country country)
        {
            Street = street;
            Number = number;
            City = city;
            Country = country;
        }

        public Address()
        {
        }

        protected override void ValidateSelf()
        {
            if (string.IsNullOrWhiteSpace(this.number))
            {
                this.ValidationErrors["StreetNumber"] = "Broj ne smije biti prazan!";
            }
            else if (!Regex.IsMatch(this.number, @"^\d+$"))
            {
                this.ValidationErrors["StreetNumber"] = "Dozvoljeni su samo brojevi!";
            }

            if (string.IsNullOrWhiteSpace(this.street))
            {
                this.ValidationErrors["Street"] = "Ulica ne smije biti prazna!";
            }
            else if (!Regex.IsMatch(this.street, "^[a-zA-Z_ ]*$"))
            {
                this.ValidationErrors["Street"] = "Ulica treba da sadrži samo slova!";
            }
            city.Validate();
            if (!city.IsValid)
            {
                this.ValidationErrors["city"] = "Adresa nije dobra!";
            }
        }
    }
}