using SIMS.Interfaces;
using SIMS.Model;
using System;
using System.Collections.Generic;

namespace SIMS.Interfaces
{
    internal interface ICityStorage
    {
        public List<City> GetAll();
        public City GetOne(String name);
        public Boolean Delete(String name);
        public Boolean Create(City city);
        public Boolean Update(City city);
    }
}
