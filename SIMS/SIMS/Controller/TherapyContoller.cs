using System.Collections.Generic;
using SIMS.Model;
using SIMS.Service;
using System;
using System.Collections.Generic;


namespace SIMS.Controller
{
    internal class TherapyContoller
    {
        private TherapyService therapyService;

        public TherapyContoller()
        {
            therapyService = new TherapyService();
        }

        public List<Therapy> GetAll()
        {
            return therapyService.GetAll();
        }

        public List<Therapy> GetById(string id)
        {
            return therapyService.GetById(id);
        }

        public Boolean Create(Therapy therapy)
        {
            return therapyService.Create(therapy);
        }
    }
}
