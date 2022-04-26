using SIMS.Model;
using SIMS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
