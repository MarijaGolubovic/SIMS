using SIMS.Interfaces;
using SIMS.Model;
using System;
using System.Collections.Generic;

namespace SIMS.Service
{
    public class DoctorService
    {
        private IDoctorStorage doctorStorage = new Repository.DoctorStorage();

        public DoctorService()
        {
            doctorStorage = new Repository.DoctorStorage();
        }

        public List<SIMS.Model.Doctor> GetAll()
        {
            return doctorStorage.GetAll();
        }

        public SIMS.Model.Doctor GetByID(String jmbg)
        {
            return doctorStorage.GetByID(jmbg);
        }

        public SIMS.Model.Doctor GetByUsername(String username)
        {
            return doctorStorage.GetByUsername(username);
        }
        public List<SIMS.Model.Doctor> GetBySpecialization(Specialization specialization)
        {
            return doctorStorage.GetBySpecialization(specialization);
        }

    }
}
