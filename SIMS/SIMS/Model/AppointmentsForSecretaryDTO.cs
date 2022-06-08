using SIMS.Model;
using SIMS.Service;
using System;
using System.Collections.Generic;

namespace SIMS.Model
{
    public class AppointmentsForSecretaryDTO
    {
        public int appointmentId { get; set; }
        public String NameSurnameDoctor { get; set; }
        public String NameSurnamePatient { get; set; }
        public String Date { get; set; }
        public String Time { get; set; }
        public String roomId { get; set; }

        public AppointmentsForSecretaryDTO(int appointmentId, string nameSurnameDoctor, string nameSurnamePatient, string date, string time, string roomId)
        {
            this.appointmentId = appointmentId;
            NameSurnameDoctor = nameSurnameDoctor;
            NameSurnamePatient = nameSurnamePatient;
            Date = date;
            Time = time;
            this.roomId = roomId;
        }
    }
}
