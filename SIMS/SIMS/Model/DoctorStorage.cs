using System;
using System.Collections.Generic;

namespace SIMS.Model
{
    public class DoctorStorage
    {
        public static List<Doctor> GetAll()     
        {
            Serialization.Serializer<DoctorSpecialization> doctorSerializer = new Serialization.Serializer<DoctorSpecialization>();
            List<DoctorSpecialization> doctorStorage = doctorSerializer.fromCSV("doctors.txt");

            Serialization.Serializer<User> userSerializer = new Serialization.Serializer<User>();
            List<User> users = userSerializer.fromCSV("user.txt");

            List<Model.Doctor> Doctors = new List<Doctor>();

            foreach (User u in users) {
                foreach (DoctorSpecialization ds in doctorStorage) {
                    if (u.Person.JMBG.Equals(ds.JMBG)) {
                        Model.Doctor doc = new Model.Doctor(u, new Specialization(ds.Spec));
                        Doctors.Add(doc);
                    }
                }
            }

            return Doctors;
        }

        public static Doctor GetByID(String jmbg)
        {
            List<Model.Doctor> Doctors = GetAll();
            Doctor doc = new Doctor();
            foreach (Doctor d in Doctors) {
                if (d.Person.JMBG.Equals(jmbg)) {
                    doc = d;
                }
            }
            return doc;
        }

        public static Doctor GetByUsername(String username)
        {
            List<Doctor> Doctors = GetAll();
            Doctor doc = new Doctor();
            foreach (Doctor d in Doctors) {
                if (d.ToString().Equals(username)) {
                    doc = d;
                    break;
                }
            }
            return doc;
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