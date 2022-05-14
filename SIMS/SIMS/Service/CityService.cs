using System.Collections.Generic;
using SIMS.Model;

namespace SIMS.Service
{

    public class CityService
    {
        private CityStorage cityStorage;

        public CityService()
        {
            cityStorage = new CityStorage();
        }

        public List<City> GetAll()
        {
            return cityStorage.GetAll();
        }

    }
}
