using System.Collections.Generic;
using SIMS.Model;

namespace SIMS.Service
{
    public class CountryService
    {
        private CountryStorage countryStorage;

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
