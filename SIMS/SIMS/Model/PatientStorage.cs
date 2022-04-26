using System;
using System.Collections.Generic;
using System.Linq;

namespace SIMS.Model
{
    public class PatientStorage
    {
        public static List<Patient> GetAll()
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

        public static Patient GetOne(String jmbg)
        {
            List<Patient> Patients = GetAll();
            Patient patient = new Patient();
            foreach (Patient p in Patients) {
                if (p.Person.JMBG.Equals(jmbg)) {
                    patient = p;
                }
            }
            return patient;
        }
        //metoda koja vraca registrovanog pacijenta
        public static Patient GetRegistrated()
        {
            //potrebno mi je da dobavim podatke ulogovanog korisnika
            //Pravim dumy podatke
            Room room = new Room("1",5, Model.RoomType.EXAMINATION_ROOM);
            City city = new City("Banjaluka");
            Country country = new Country("BIH");
            Specialization specialization = new Specialization("pedijatar");
            Address address = new Address("Stefanova", "5", city, country);
            Person person = new Person("Tamara", "Antic", "1111010103256", "065087003", DateTime.Parse("10-10-2020"), "tasaantic00@gmail.com", address);
            User user = new User("tasa", "tasa123", UserType.doctor, person);
            Doctor doctor = new Doctor(user, specialization);
            AccountStatus accountStatus = new AccountStatus(true, true);
            List<String> ingredians = new List<string> { "sastojak1", "sastojak2" };
            Medicine medicine = new Medicine("bromazepan", ingredians);
            List<Medicine> medicines = new List<Medicine> { medicine };
            MedicalRecord medicalRecord = new MedicalRecord(1.65, 55, "none", BloodType.abNegative, medicines);
            Patient patient = new Patient(user, medicalRecord, accountStatus);

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