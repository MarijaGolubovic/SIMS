using SIMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
