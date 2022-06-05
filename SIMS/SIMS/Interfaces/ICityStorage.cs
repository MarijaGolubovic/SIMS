using SIMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
