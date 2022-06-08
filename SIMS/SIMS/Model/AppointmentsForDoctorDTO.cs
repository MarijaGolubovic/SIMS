using SIMS.Model;
using SIMS.Service;
using System;
using System.Collections.Generic;

namespace SIMS.Model
{
    public class AppointmentsForDoctorDTO
    {
        public int appointmentId { get; set; }
        public String Name { get; set; }
        public String Surname { get; set; }
        public String Date { get; set; }
        public String Time { get; set; }
        public String roomId { get; set; }

        public String DoctorId { get; set; }

        public AppointmentsForDoctorDTO(int appointmentId, string name, string surname, string date, string time, string roomId, string doctorId)
        {
            this.appointmentId = appointmentId;
            Name = name;
            Surname = surname;
            Date = date;
            Time = time;
            this.roomId = roomId;
            DoctorId = doctorId;
        }
    }
}
