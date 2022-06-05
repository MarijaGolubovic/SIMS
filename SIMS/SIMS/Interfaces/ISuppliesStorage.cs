using SIMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Interfaces
{
    internal interface ISuppliesStorage
    {
        public List<Supplies> GetAll();
        public Supplies GetOne(String name);
        public Boolean Update(Supplies supp);
    }
}
