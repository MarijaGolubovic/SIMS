using SIMS.Interfaces;
using SIMS.Model;
using System;
using System.Collections.Generic;

namespace SIMS.Interfaces
{
    internal interface ISpecializationStorage
    {
        public List<Specialization> GetAll();
        public List<Specialization> GetAllSpecialist();
        public List<Specialization> GetAllOpstePrakse();
    }
}
