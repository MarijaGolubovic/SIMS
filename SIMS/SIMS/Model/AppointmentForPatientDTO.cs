using SIMS.Model;
using SIMS.Service;
using System;
using System.Collections.Generic;


namespace SIMS.Model
{
    public class AppointmentForPatientDTO
    {
        public Doctor Doctor { get; set; }
        public DateTime DateTime { get; set; }
        public User User { get; set; }
        public bool Priority { get; set; }
        public AppointmentForPatientDTO(Doctor doctor, DateTime dateTime, User user, bool priority)
        {
            this.Doctor = doctor;
            this.DateTime = dateTime;
            this.User = user;
            this.Priority = priority;
        }


    }
}
