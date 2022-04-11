using System;
using System.Collections.Generic;

namespace SIMS.Model
{
    public class PatientStorage
    {
        public List<Patient> GetAll()
        {
            throw new NotImplementedException();
        }

        public static Patient GetOne(String jmbg)  //nisam sigurna zasto
        {
            //Pravim dumy podatke
            City city = new City("Banjaluka");
            Country country = new Country("BIH");
            Specialization specialization = new Specialization("pedijatar");
            Address address = new Address("Stefanova", "5", city, country);
            Person person = new Person("Marko", "Markovic", jmbg, "065087003", DateTime.Parse("10-10-2020"), "tasaantic00@gmail.com", address);
            User user = new User("tasa", "tasa123", UserType.doctor, person);
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