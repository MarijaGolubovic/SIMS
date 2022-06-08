using SIMS.Interfaces;
using SIMS.Model;
using SIMS.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SIMS.Model
{
    public class CityStorage : ICityStorage
    {
        public List<City> GetAll()
        {
            List<City> cities = new List<City>();
            Serialization.Serializer<City> citySerijalization = new Serialization.Serializer<City>();
            cities = citySerijalization.fromCSV("City.txt");
            return cities;
        }

        public City GetOne(String name)
        {
            List<City> cities = new List<City>();
            City city = new City();
            Serialization.Serializer<City> citySerijalization = new Serialization.Serializer<City>();
            cities = citySerijalization.fromCSV("City.txt");
            foreach (City inputCity in cities)
            {
                if (name.Equals(inputCity.Name))
                {
                    city = inputCity;
                }
            }
            return city;
        }

        public Boolean Delete(String name)
        {
            List<City> cities = new List<City>();
            Boolean status = false;
            Serialization.Serializer<City> citySerijalization = new Serialization.Serializer<City>();
            cities = citySerijalization.fromCSV("City.txt");
            foreach (City inputCity in cities)
            {
                if (name.Equals(inputCity.Name))
                {
                    cities.Remove(inputCity);
                    status = true;
                }
            }

            return status;
        }

        public Boolean Create(City city)
        {
            List<City> cities = new List<City>();
            Boolean status = false;
            Serialization.Serializer<City> citySerijalization = new Serialization.Serializer<City>();
            cities = citySerijalization.fromCSV("City.txt");
            cities.Add(city);
            citySerijalization.toCSV("City.txt", cities);
            status = true;
            return status;

        }

        public Boolean Update(City city)
        {
            throw new NotImplementedException();
        }

        public String fileName;

    }
}