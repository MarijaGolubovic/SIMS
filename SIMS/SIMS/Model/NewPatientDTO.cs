using SIMS.Model;
using SIMS.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
namespace SIMS.Model
{
    public class NewPatientDTO
    {
        public String Name { get; set; }
        public String Surname { get; set; }
        public DateTime DateTime { get; set; }
        public String PhoneNumber { get; set; }

        public String JMBG { get; set; }

        public NewPatientDTO(string name, string surname, DateTime dateTime, string phoneNumber, string jMBG)
        {
            Name = name;
            Surname = surname;
            DateTime = dateTime;
            PhoneNumber = phoneNumber;
            JMBG = jMBG;
        }
    }
}
