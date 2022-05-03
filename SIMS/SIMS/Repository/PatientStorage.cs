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

            return Patients;
        }
        //2212010103158
        public Patient GetOne(String jmbg)
        {
            List<Patient> Patients = GetAll();
            Patient patient = new Patient();

            patient = Patients.Find(u => u.Person.JMBG.Equals(jmbg));

            return patient;
        }

        public Boolean Delete(String jmbg)
        {
            throw new NotImplementedException();
        }

        public Boolean Create(Patient patient)
        {
            Serialization.Serializer<Patient> patientSerializer = new Serialization.Serializer<Patient>();
            List<Patient> patients = new List<Patient>();
            foreach (Patient p in patientSerializer.fromCSV("patients.txt"))
            {
                patients.Add(p);
            }
            patients.Add(patient);
            patientSerializer.toCSV("patients.txt", patients);
            return true;
        }

        public Boolean Update(String jmbg, AccountStatus accountStatus)
        {
            Serialization.Serializer<Patient> patientSerializer = new Serialization.Serializer<Patient>();
            List<Patient> patients = new List<Patient>();
            foreach (Patient p in patientSerializer.fromCSV("patients.txt"))
            {
                patients.Add(p);
            }
            patients.Remove(patients.Find(p => p.JMBGP.Equals(jmbg)));
            patients.Add(new Patient(jmbg, accountStatus.initialAccount, accountStatus.activatedAccount));
            patientSerializer.toCSV("patients.txt", patients);
            return true;
        }
        public Boolean UpdateJMBG(String jmbgOld, String jmbgNew)
        {
            Serialization.Serializer<Patient> patientSerializer = new Serialization.Serializer<Patient>();
            List<Patient> patients = new List<Patient>();
            foreach (Patient p in patientSerializer.fromCSV("patients.txt"))
            {
                patients.Add(p);
            }
            patients.Add(new Patient(jmbgNew, patients.Find(p => p.JMBGP.Equals(jmbgOld)).InitialAccount, patients.Find(p => p.JMBGP.Equals(jmbgOld)).ActivatedAccount));
            patients.Remove(patients.Find(p => p.JMBGP.Equals(jmbgOld)));

            patientSerializer.toCSV("patients.txt", patients);
            return true;
        }


        public String fileName;

    }
}