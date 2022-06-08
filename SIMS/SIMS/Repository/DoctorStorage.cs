using SIMS.Interfaces;
using SIMS.Model;
using SIMS.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
namespace SIMS.Repository
{
    public class DoctorStorage : IDoctorStorage
    {
        private Serialization.Serializer<DoctorSpecialization> doctorSerializer;
        private Serialization.Serializer<User> userSerializer;

        public DoctorStorage()
        {
            doctorSerializer = new Serialization.Serializer<DoctorSpecialization>();
            userSerializer = new Serialization.Serializer<User>();
        }

        public List<Model.Doctor> LinkDoctorsWithSpecializations(List<User> users, List<DoctorSpecialization> specializationsForDoctors)
        {
            List<Model.Doctor> doctors = new List<Model.Doctor>();

            foreach (User user in users)
            {
                IfSameJMBGLinkSpecialization(specializationsForDoctors, doctors, user);
            }

            return doctors;
        }

        public void IfSameJMBGLinkSpecialization(List<DoctorSpecialization> specializationsForDoctors, List<Doctor> doctors, User user)
        {
            foreach (DoctorSpecialization doctorSpecialization in specializationsForDoctors)
            {
                if (user.Person.JMBG.Equals(doctorSpecialization.JMBG))
                {
                    Model.Doctor doctor = new Model.Doctor(user, new Specialization(doctorSpecialization.Spec));
                    doctors.Add(doctor);
                }
            }
        }

        public List<SIMS.Model.Doctor> GetAll()
        {

            List<DoctorSpecialization> specializationsForDoctors = doctorSerializer.fromCSV("doctors.txt");
            List<User> users = userSerializer.fromCSV("user.txt");

            List<Model.Doctor> doctors = LinkDoctorsWithSpecializations(users, specializationsForDoctors);

            return doctors;
        }

        public SIMS.Model.Doctor GetByID(String JMBG)
        {
            SIMS.Model.Doctor doctor = new SIMS.Model.Doctor();
            foreach (SIMS.Model.Doctor d in GetAll())
            {
                if (d.Person.JMBG.Equals(JMBG))
                {
                    doctor = d;
                }
            }
            return doctor;
        }

        public SIMS.Model.Doctor GetByUsername(String username)
        {
            SIMS.Model.Doctor doctor = new SIMS.Model.Doctor();
            foreach (SIMS.Model.Doctor d in GetAll())
            {
                if (d.ToString().Equals(username))
                {
                    doctor = d;
                    break;
                }
            }
            return doctor;
        }

        public List<SIMS.Model.Doctor> GetBySpecialization(Specialization specialization)
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