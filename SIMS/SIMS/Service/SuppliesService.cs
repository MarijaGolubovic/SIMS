using SIMS.Interfaces;
using SIMS.Model;
using SIMS.Repository;
using SIMS.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SIMS.Service
{
    class SuppliesService
    {
        private ISuppliesStorage suppliesStorage = new SuppliesStorage();
        public List<Supplies> GetAll()
        {
            return suppliesStorage.GetAll();
        }

        public Supplies GetOne(String name)
        {
            return suppliesStorage.GetOne(name);
        }

        public Boolean Update(Supplies supplies)
        {
            return suppliesStorage.Update(supplies);
        }
    }
}
