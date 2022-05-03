using System;
using System.Collections.Generic;
using SIMS.Model;

namespace SIMS.Service
{
    public class PatientService
    {
        private PatientStorage patientStorage;

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

        public void Update(String jmbg, AccountStatus accountStatus)
        {
            patientStorage.Update(jmbg, accountStatus);
        }

        public Boolean UpdateJMBG(String jmbgOld, String jmbgNew)
        {
            return patientStorage.UpdateJMBG(jmbgOld, jmbgNew);
        }

    }
}
