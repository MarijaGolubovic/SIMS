using SIMS.Interfaces;
using SIMS.Model;
using System;
using System.Collections.Generic;

namespace SIMS.Interfaces
{
    internal interface ICountryStorage
    {
        public List<Country> GetAll();
        public Country GetOne(String name);
        public Boolean Delete(String name);
        public Boolean Create(Country country);
        public Boolean Update(Country country);
    }
}
