using System.Collections.Generic;
using SIMS.Model;
using SIMS.Repository;

namespace SIMS.Service
{
    internal class TherapyService
    {
        public TherapyStorage therapyStorage;

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
    }
}
