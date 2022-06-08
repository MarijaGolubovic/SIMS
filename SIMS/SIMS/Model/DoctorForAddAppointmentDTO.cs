using SIMS.Model;
using SIMS.Service;
using System;
using System.Collections.Generic;

namespace SIMS.Model
{
    public class DoctorForAddAppointmentDTO
    {
        public String Id { get; set; }
        public String Name { get; set; }
        public String Surname { get; set; }
        public String Specialization { get; set; }
        public String DateOfBirth { get; set; }

        public DoctorForAddAppointmentDTO(string id, string name, string surname, string specialization, string dateOfBirth)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Specialization = specialization;
            DateOfBirth = dateOfBirth;
        }


    }
}
