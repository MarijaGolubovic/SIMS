using SIMS.Model;
using SIMS.Service;
using System;
using System.Collections.Generic;


namespace SIMS.Controller
{
    class CityController
    {
        private readonly CityService cityService;

        public CityController()
        {
            cityService = new CityService();
        }
        public List<City> GetAll()
        {
            return cityService.GetAll();
        }

    }
}
