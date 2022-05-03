using System;
using System.Collections.Generic;
using SIMS.Model;
namespace SIMS.Repository
{
    public class DoctorStorage
    {
        public static List<SIMS.Model.Doctor> GetAll()
        {
            Serialization.Serializer<DoctorSpecialization> doctorSerializer = new Serialization.Serializer<DoctorSpecialization>();
            List<DoctorSpecialization> doctorStorage = doctorSerializer.fromCSV("doctors.txt");

            Serialization.Serializer<User> userSerializer = new Serialization.Serializer<User>();
            List<User> users = userSerializer.fromCSV("user.txt");

            List<Model.Doctor> Doctors = new List<SIMS.Model.Doctor>();

            foreach (User u in users)
            {
                foreach (DoctorSpecialization ds in doctorStorage)
                {
                    if (u.Person.JMBG.Equals(ds.JMBG))
                    {
                        Model.Doctor doc = new Model.Doctor(u, new Specialization(ds.Spec));
                        Doctors.Add(doc);
                    }
                }
            }

            return Doctors;
        }

        public static SIMS.Model.Doctor GetByID(String jmbg)
        {
            List<Model.Doctor> Doctors = GetAll();
            SIMS.Model.Doctor doc = new SIMS.Model.Doctor();
            foreach (SIMS.Model.Doctor d in Doctors)
            {
                if (d.Person.JMBG.Equals(jmbg))
                {
                    doc = d;
                }
            }
            return doc;
        }

        public static SIMS.Model.Doctor GetByUsername(String username)
        {
            List<SIMS.Model.Doctor> Doctors = GetAll();
            SIMS.Model.Doctor doc = new SIMS.Model.Doctor();
            foreach (SIMS.Model.Doctor d in Doctors)
            {
                if (d.ToString().Equals(username))
                {
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

        public static List<SIMS.Model.Doctor> GetBySpecialization(Specialization specialization)
        {
            List<SIMS.Model.Doctor> doctors = new List<Model.Doctor>();
            foreach (SIMS.Model.Doctor d in GetAll())
            {
                if (d.Specialization.Name.Equals(specialization.Name))
                {
                    doctors.Add(d);
                }
            }
            return doctors;
        }

        public String fileName;


    }
}