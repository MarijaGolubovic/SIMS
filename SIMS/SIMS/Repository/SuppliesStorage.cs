using SIMS.Interfaces;
using SIMS.Model;
using SIMS.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SIMS.Repository
{
    class SuppliesStorage : ISuppliesStorage
    {
        public List<Supplies> GetAll()
        {
            List<Supplies> supplies = new List<Supplies>();
            Serialization.Serializer<Supplies> suppliesSerialization = new Serialization.Serializer<Supplies>();
            supplies = suppliesSerialization.fromCSV("supplies.txt");

            return supplies;
        }

        public Supplies GetOne(String name)
        {
            return GetAll().Find(s => s.Name.Equals(name));
        }

        public Boolean Update(Supplies supp)
        {
            List<Supplies> supplies = GetAll();
            Serialization.Serializer<Supplies> serializer = new Serialization.Serializer<Supplies>();
            supplies.Remove(supplies.Find(s => s.Name.Equals(supp.Name)));
            supplies.Add(supp);
            serializer.toCSV("supplies.txt", supplies);
            return true;
        }
    }
}
