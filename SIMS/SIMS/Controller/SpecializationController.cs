using SIMS.Model;
using SIMS.Service;
using System;
using System.Collections.Generic;


namespace SIMS.Controller
{
    class SpecializationController
    {
        private readonly SpecializationsService specializatiosService;

        public SpecializationController()
        {
            specializatiosService = new SpecializationsService();
        }

        public List<Specialization> GetAll()
        {
            return specializatiosService.GetAll();
        }
        public List<Specialization> GetAllSpecialist()
        {
            return specializatiosService.GetAllSpecialist();
        }

        public List<Specialization> GetAllOpstePrakse()
        {
            return specializatiosService.GetAllOpstePrakse();
        }
    }
}
