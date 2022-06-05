using System.Collections.Generic;
using SIMS.Interfaces;
using SIMS.Model;

namespace SIMS.Service
{

    public class CityService
    {
        private ICityStorage cityStorage;

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
