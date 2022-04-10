using System;
using System.Collections.Generic;

namespace SIMS.Model
{
    public class DoctorStorage
    {
        public List<Doctor> GetAll()
        {
            throw new NotImplementedException();
        }

        public Doctor GetByID(String jmbg)
        {
            throw new NotImplementedException();
        }

        public Boolean Delete(String jmbg)
        {
            throw new NotImplementedException();
        }

        public Boolean Create(String jmbg, Specialization specialization)
        {
            throw new NotImplementedException();
        }

        public Boolean Update(String jmbg, Specialization specialization)
        {
            throw new NotImplementedException();
        }

        public List<Doctor> GetBySpecialization(Specialization specialization)
        {
            throw new NotImplementedException();
        }

        public String fileName;

    }
}