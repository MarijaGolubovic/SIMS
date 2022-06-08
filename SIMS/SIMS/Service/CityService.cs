using SIMS.Interfaces;
using SIMS.Model;
using SIMS.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;

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
