using System;
using System.Collections.Generic;
using SIMS.Model;
using SIMS.Service;

namespace SIMS.Controller
{
    public class DoctorController
    {
        private Service.DoctorService doctorService;

        public DoctorController()
        {
            doctorService = new DoctorService();
        }
        //GetAll
        public static List<SIMS.Model.Doctor> GetAll()
        {
            return DoctorService.GetAll();
        }
        public static SIMS.Model.Doctor GetByID(String jmbg)
        {
            return DoctorService.GetByID(jmbg);
        }

        public static SIMS.Model.Doctor GetByUsername(String username)
        {
            return DoctorService.GetByUsername(username);
        }

        public static List<SIMS.Model.Doctor> GetBySpecialization(Specialization specialization)
        {
            return DoctorService.GetBySpecialization(specialization);
        }

    }
}
