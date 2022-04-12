using System;
using System.Collections.Generic;

namespace SIMS.Model
{
   public class CountryStorage
   {
      public List<Country> GetAll()
      {
            List<Country> countries = new List<Country>();
            Serialization.Serializer<Country> countrySerijalization = new Serialization.Serializer<Country>();
            countries = countrySerijalization.fromCSV("Country.csv");
            return countries;
        }
      
      public Country GetOne(String name)
      {
            List<Country> countries = new List<Country>();
            Country country = new Country();
            Serialization.Serializer<Country> countrySerijalization = new Serialization.Serializer<Country>();
            countries = countrySerijalization.fromCSV("Country.csv");
            foreach(Country inputCountry in countries)
            {
                if (name.Equals(inputCountry.Name))
                {
                    country = inputCountry;
                }
            }
            return country;
        }
      
      public Boolean Delete(String name)
      {
            List<Country> countries = new List<Country>();
            Boolean status = false;
            Serialization.Serializer<Country> countrySerijalization = new Serialization.Serializer<Country>();
            countries = countrySerijalization.fromCSV("Country.csv");
            foreach(Country inputCountry in countries)
            {
                if (name.Equals(inputCountry.Name))
                {
                    countries.Remove(inputCountry);
                    status = true;
                }
            }
            return status;
        }
      
      public Boolean Create(Country country)
      {
            List<Country> countries = new List<Country>();
            Boolean status = false;
            Serialization.Serializer<Country> countrySerijalization = new Serialization.Serializer<Country>();
            countries = countrySerijalization.fromCSV("Country.csv");
            countries.Add(country);
            countrySerijalization.toCSV("Country.csv", countries);
            status = true;
            return status;
        }
      
      public Boolean Update(Country country)
      {
         throw new NotImplementedException();
      }
      
      public String fileName;
   
   }
}