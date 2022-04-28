using System;
using System.Collections.Generic;
using System.Linq;

namespace SIMS.Model
{
    public class PatientStorage
    {
        public List<Patient> GetAll()
        {
            Serialization.Serializer<User> userSerializer = new Serialization.Serializer<User>();
            List<User> users = userSerializer.fromCSV("user.txt");

            Serialization.Serializer<Patient> patientSerializer = new Serialization.Serializer<Patient>();
            List<Patient> patientSer = patientSerializer.fromCSV("patients.txt");

            List<Patient> Patients = new List<Patient>();

            if (patientSer.ToList().Any())
            {
                foreach (User item in users)
                {
                    foreach (Patient itemP in patientSer)
                    {
                        if (itemP.JMBGP.Equals(item.Person.JMBG))
                        {
                            if (itemP.ActivatedAccount)
                            {
                                Patients.Add(new Patient(item, new MedicalRecord(), new AccountStatus(false, true)));
                            }
                            else
                            {
                                Patients.Add(new Patient(item, new MedicalRecord(), new AccountStatus(false, false)));
                            }
                        }
                    }
                }
            }

            return Patients;
        }
        //2212010103158
        public Patient GetOne(String jmbg)
        {
            List<Patient> Patients = GetAll();
            Patient patient = new Patient();
            foreach (Patient p in Patients)
            {
                if (p.Person.JMBG.Equals(jmbg))
                {
                    patient = p;
                }
            }    
            return patient;
        }

        public Boolean Delete(String jmbg)
        {
            throw new NotImplementedException();
        }

        public Boolean Create(String jmbg, AccountStatus acountStatus)
        {
            throw new NotImplementedException();
        }

        public Boolean Update(String jmbg, AccountStatus accountStatus)
        {
            throw new NotImplementedException();
        }

        public String fileName;

    }
}