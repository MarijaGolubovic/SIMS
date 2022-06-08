using SIMS.Interfaces;
using SIMS.Model;
using SIMS.Repository;
using SIMS.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;


namespace SIMS.Service
{
    internal class TherapyService
    {
        public ITherapyStorage therapyStorage;

        public TherapyService()
        {
            therapyStorage = new TherapyStorage();
        }

        public List<Therapy> GetAll()
        {
            return therapyStorage.GetAll();
        }

        public List<Therapy> GetById(string id)
        {
            return therapyStorage.GetById(id);
        }

        public Boolean Create(Therapy therapy)
        {
            return therapyStorage.Create(therapy);
        }
    }
}
