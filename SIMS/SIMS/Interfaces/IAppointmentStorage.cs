using SIMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Interfaces
{
    internal interface IAppointmentStorage
    {
        public static List<Appointment> GetAll();
        public Appointment GetOne(int appointmentID);
        public Boolean Delete(int appointmentID);
        public Boolean Create(Appointment appointment);
        public Boolean DeleteApp(DateTime dateTime, String roomId);
    }
}
