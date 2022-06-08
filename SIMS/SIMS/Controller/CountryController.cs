using SIMS.Model;
using SIMS.Service;
using System;
using System.Collections.Generic;


namespace SIMS.Controller
{
    public class CountryController
    {
        private readonly CountryService countryService;

        public CountryController()
        {
            countryService = new CountryService();
        }

        public List<Country> GetAll()
        {
            return countryService.GetAll();
        }
    }
}
