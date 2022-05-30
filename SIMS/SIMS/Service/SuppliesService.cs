﻿using System;
using System.Collections.Generic;
using SIMS.Model;
using SIMS.Repository;

namespace SIMS.Service
{
    class SuppliesService
    {
        private SuppliesStorage suppliesStorage = new SuppliesStorage();
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