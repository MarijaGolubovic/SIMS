using SIMS.Interfaces;
using SIMS.Model;
using System;
using System.Collections.Generic;

namespace SIMS.Interfaces
{
    internal interface IAppointmentStorage
    {
        public Appointment GetOne(int appointmentID);
        public Boolean Delete(int appointmentID);
        public Boolean Create(Appointment appointment);
        public Boolean DeleteApp(DateTime dateTime, String roomId);
        public List<Appointment> GetAll();
    }
}
