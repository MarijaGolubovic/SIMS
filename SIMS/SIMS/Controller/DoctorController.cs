using System;
using System.Collections.Generic;
using SIMS.Model;
using SIMS.Service;

namespace SIMS.Controller
{
    public class DoctorController
    {
        private readonly Service.DoctorService doctorService = new DoctorService();

        public DoctorController()
        {
        }
        //GetAll
        public List<SIMS.Model.Doctor> GetAll()
        {
            return doctorService.GetAll();
        }
        public SIMS.Model.Doctor GetByID(String jmbg)
        {
            return doctorService.GetByID(jmbg);
        }

        public SIMS.Model.Doctor GetByUsername(String username)
        {
            return doctorService.GetByUsername(username);
        }

        public List<SIMS.Model.DoctorForAddAppointmentDTO> GetDoctorForAddAppointment() 
        {
            List<SIMS.Model.Doctor> doctors = GetAll();
            List<SIMS.Model.DoctorForAddAppointmentDTO> retList = new List<SIMS.Model.DoctorForAddAppointmentDTO>();

            foreach (SIMS.Model.Doctor d in doctors)
            {
                String specialization;
                if (d.Specialization == null) {
                    specialization = "Nema";
                }
                else {
                    specialization = d.Specialization.Name;
                }
                SIMS.Model.DoctorForAddAppointmentDTO doc = new SIMS.Model.DoctorForAddAppointmentDTO(d.Person.JMBG, d.Person.Name, d.Person.Surname, specialization, d.Person.DateOfBirth.ToString().Split(' ')[0]);
                retList.Add(doc);
            }

            return retList;
        }

        public List<SIMS.Model.Doctor> GetBySpecialization(Specialization specialization)
        {
            return doctorService.GetBySpecialization(specialization);
        }

    }
}
