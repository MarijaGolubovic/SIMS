using SIMS.Interfaces;
using SIMS.Model;
using SIMS.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SIMS.Service
{
    public class CountryService
    {
        private ICountryStorage countryStorage;

        public CountryService()
        {
            countryStorage = new CountryStorage();
        }

        public List<Country> GetAll()
        {
            return countryStorage.GetAll();
        }


    }
}
