using System;
using System.Collections.Generic;

namespace SIMS.Model
{
    public class DoctorStorage
    {
        public static List<Doctor> GetAll()         //static
        {
            //Privremeni dumy podaci za listu doktora
            //Kasnije treba da dobavljaju listu iz fajla
            List<Doctor> doctors = new List<Doctor>();

            City city = new City("Banjaluka");
            Country country = new Country("BIH");
            Specialization specialization = new Specialization("pedijatar");
            Address address = new Address("Stefanova", "5", city, country);
            Person person = new Person("Tamara", "Antic", "123456789", "065087003", DateTime.Parse("10-10-2020"), "tasaantic00@gmail.com", address);
            User user = new User("tasa", "tasa123", UserType.doctor, person);
            Doctor doctor = new Doctor(user, specialization);
            Doctor doctor1 = new Doctor(user, specialization);

            doctors.Add(doctor);
            doctors.Add(doctor1);
            return doctors;
        }

        public static Doctor GetByID(String jmbg)
        {
            //Pravim dumy podatke
            Room room = new Room("1", 5,Model.RoomType.EXAMINATION_ROOM);
            City city = new City("Banjaluka");
            Country country = new Country("BIH");
            Specialization specialization = new Specialization("pedijatar");
            Address address = new Address("Stefanova", "5", city, country);
            Person person = new Person("Tamara", "Antic", jmbg, "065087003", DateTime.Parse("10-10-2020"), "tasaantic00@gmail.com", address);
            User user = new User("tasa", "tasa123", UserType.doctor, person);
            Doctor doctor = new Doctor(user, specialization);

            return doctor;
        }

        public static Doctor GetByUsername(String username)
        {
            //Pravim dumy podatke
            Room room = new Room("1", 5, Model.RoomType.EXAMINATION_ROOM);
            City city = new City("Banjaluka");
            Country country = new Country("BIH");
            Specialization specialization = new Specialization("pedijatar");
            Address address = new Address("Stefanova", "5", city, country);
            Person person = new Person("Tamara", "Antic", "123456789", "065087003", DateTime.Parse("10-10-2020"), "tasaantic00@gmail.com", address);
            User user = new User(username, "tasa123", UserType.doctor, person);
            Doctor doctor = new Doctor(user, specialization);

            return doctor;
        }

        public Boolean Delete(String jmbg)
        {
            throw new NotImplementedException();
        }

        public Boolean Create(String jmbg, Specialization specialization)
        {
            throw new NotImplementedException();
        }

        public Boolean Update(String jmbg, Specialization specialization)
        {
            throw new NotImplementedException();
        }

        public List<Doctor> GetBySpecialization(Specialization specialization)
        {
            throw new NotImplementedException();
        }

        public String fileName;

    }
}