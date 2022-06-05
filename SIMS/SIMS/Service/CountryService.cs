using System.Collections.Generic;
using SIMS.Interfaces;
using SIMS.Model;

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
