using System.Collections.Generic;
using SIMS.Model;

namespace SIMS.Service
{
    public class SpecializationsService
    {
        private SpecializationStorage specializationStorage;
        public SpecializationsService()
        {
            specializationStorage = new SpecializationStorage();
        }
        public List<Specialization> GetAll()
        {
            return specializationStorage.GetAll();
        }
        public List<Specialization> GetAllSpecialist()
        {
            return specializationStorage.GetAllSpecialist();
        }

        public List<Specialization> GetAllOpstePrakse()
        {
            return specializationStorage.GetAllOpstePrakse();
        }
    }
}
