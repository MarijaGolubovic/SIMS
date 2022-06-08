using SIMS.Interfaces;
using SIMS.Model;
using System;
using System.Collections.Generic;

namespace SIMS.Interfaces
{
    internal interface ISuppliesStorage
    {
        public List<Supplies> GetAll();
        public Supplies GetOne(String name);
        public Boolean Update(Supplies supp);
    }
}
