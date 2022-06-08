using SIMS.Interfaces;
using SIMS.Model;
using SIMS.Repository;
using SIMS.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SIMS.Service
{
    public class PatientService
    {
        private IPatientStorage patientStorage;

        public PatientService()
        {
            patientStorage = new PatientStorage();
        }

        public List<Patient> GetAll()
        {
            return patientStorage.GetAll();
        }

        public Patient GetOne(String jmbg)
        {
            return patientStorage.GetOne(jmbg);
        }

        public List<Patient> GetAllActiv()
        {
            List<Patient> patients = patientStorage.GetAll();
            List<Patient> patientsActiv = new List<Patient>();
            foreach (Patient p in patients)
            {
                if (p.AccountStatus.activatedAccount)
                {
                    patientsActiv.Add(p);
                }
            }

            return patientsActiv;

        }

        public List<Patient> GetAllBlock()
        {
            List<Patient> patients = patientStorage.GetAll();
            List<Patient> patientsBlock = new List<Patient>();
            foreach (Patient p in patients)
            {
                if (!p.AccountStatus.activatedAccount)
                {
                    patientsBlock.Add(p);
                }
            }

            return patientsBlock;

        }

        public Boolean Create(Patient patient)
        {
            if (patientStorage.GetOne(patient.Person.JMBG) == null)
            {
                patientStorage.Create(patient);
                return true;
            }
            else
            {
                return false;
            }

        }

        internal void Update(Patient patient)
        {
            patientStorage.Update(patient);
        }

        public void Update(String jmbg, AccountStatus accountStatus)
        {
            patientStorage.Update(jmbg, accountStatus);
        }

        public Boolean UpdateJMBG(String jmbgOld, String jmbgNew)
        {
            return patientStorage.UpdateJMBG(jmbgOld, jmbgNew);
        }

        public List<PatientForAddAppointmentDTO> filterPatients(String query, List<PatientForAddAppointmentDTO> patients)
        {
            List<PatientForAddAppointmentDTO> retList = new List<PatientForAddAppointmentDTO>();
            String name = query.Split(' ')[0];
            String surname = query.Split(' ')[1];

            foreach (PatientForAddAppointmentDTO p in patients)
            {
                if (p.PatientName.StartsWith(name) || p.PatientSurname.StartsWith(surname))
                {
                    retList.Add(p);
                }
            }

            return retList;
        }

        public List<String> LinkPatientInformationsForAddAppointment()
        {
            List<String> retList = new List<String>();
            foreach (Patient patient in GetAll())
            {
                String pom = patient.Person.Name + " " + patient.Person.Surname + ", " + patient.Person.DateOfBirth.ToString().Split(' ')[0];
                retList.Add(pom);
            }
            return retList;
        }
    }
}
