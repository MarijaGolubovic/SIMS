using SIMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Interfaces
{
    internal interface ISpecializationStorage
    {
        public List<Specialization> GetAll();
        public List<Specialization> GetAllSpecialist();
        public List<Specialization> GetAllOpstePrakse();
    }
}
