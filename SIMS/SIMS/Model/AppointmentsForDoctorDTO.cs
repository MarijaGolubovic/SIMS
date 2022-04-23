using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Model
{
    public class AppointmentsForDoctorDTO
    {

        public String Name { get; set; }
        public String Surname { get; set; }
        public String Date { get; set; }
        public String Time { get; set; }
        public String roomId { get; set; }

        public AppointmentsForDoctorDTO(string name, string surname, string date, string time, string roomId)
        {
            Name = name;
            Surname = surname;
            Date = date;
            Time = time;
            this.roomId = roomId;
        }
    }
}
