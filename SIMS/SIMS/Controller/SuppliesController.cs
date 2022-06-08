using SIMS.Model;
using SIMS.Service;
using System;
using System.Collections.Generic;


namespace SIMS.Controller
{
    class SuppliesController
    {
        private SuppliesService suppliesService = new SuppliesService();

        public List<Supplies> GetAll()
        {
            return suppliesService.GetAll();
        }

        public Supplies GetOne(String name)
        {
            return suppliesService.GetOne(name);
        }

        public Boolean Update(Supplies supplies)
        {
            return suppliesService.Update(supplies);
        }

        public Boolean TransferToWarehouse(Supplies supplies)
        {
            supplies.Quantity += supplies.NewQuantity;
            supplies.NewQuantity = 0;
            return suppliesService.Update(supplies);
        }
    }
}
