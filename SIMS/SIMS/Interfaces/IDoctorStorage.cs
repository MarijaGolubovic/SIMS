using SIMS.Interfaces;
using SIMS.Model;
using System;
using System.Collections.Generic;

namespace SIMS.Interfaces
{
    internal interface IDoctorStorage
    {
        public List<Model.Doctor> LinkDoctorsWithSpecializations(List<User> users, List<DoctorSpecialization> specializationsForDoctors);
        public void IfSameJMBGLinkSpecialization(List<DoctorSpecialization> specializationsForDoctors, List<Doctor> doctors, User user);
        public List<SIMS.Model.Doctor> GetAll();
        public SIMS.Model.Doctor GetByID(String JMBG);
        public SIMS.Model.Doctor GetByUsername(String username);
        public List<SIMS.Model.Doctor> GetBySpecialization(Specialization specialization);
    }
}
