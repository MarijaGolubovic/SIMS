using SIMS.Model;
using SIMS.Service;
using System;
using System.Collections.Generic;

namespace SIMS.Controller
{
    public class PatientController
    {
        private readonly PatientService patientService;

        public PatientController()
        {
            patientService = new PatientService();
        }

        public List<Patient> GetAll()
        {
            return patientService.GetAll();
        }

        public Patient GetOne(String jmbg)
        {
            return patientService.GetOne(jmbg);
        }

        public List<Patient> GetAllActiv()
        {
            return patientService.GetAllActiv();
        }

        public List<Patient> GetAllBlock()
        {
            return patientService.GetAllBlock();
        }

        public void Update(Patient patient)
        {
            patientService.Update(patient.Person.JMBG, patient.AccountStatus);
        }

        public Boolean Create (Patient patient)
        {
            return patientService.Create(patient);
        }

        public Boolean UpdateJMBG(String jmbgOld, String jmbgNew)
        {
            return patientService.UpdateJMBG(jmbgOld, jmbgNew);
        }

        public List<PatientForAddAppointmentDTO> GetPatientForAddAppointment() 
        {
            List<PatientForAddAppointmentDTO> list = new List<PatientForAddAppointmentDTO>();

            foreach(Patient p in GetAll())
            {
                String date = p.Person.DateOfBirth.ToString().Split(' ')[0];
                String address = p.Person.Address.City.Name + ", " + p.Person.Address.Street + ", " + p.Person.Address.Number;
                PatientForAddAppointmentDTO patient = new PatientForAddAppointmentDTO(p.Person.JMBG, p.Person.Name, p.Person.Surname, address, date);
                list.Add(patient);
            }
            return list;
        }

        public List<PatientForAddAppointmentDTO> filterPatients(String query, List<PatientForAddAppointmentDTO> patients)
        {
            return patientService.filterPatients(query, patients);
        }
    }
}
