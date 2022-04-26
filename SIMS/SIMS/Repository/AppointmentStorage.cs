using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace SIMS.Model
{
    public class AppointmentStorage
    {
        public AppointmentStorage() { }
        public List<Appointment> GetAll()
        {
            Serialization.Serializer<Appointment> appointmentSerializer = new Serialization.Serializer<Appointment>();
            List<Appointment> appointments = appointmentSerializer.fromCSV("appointments.txt");
           
            return appointments;
        }

        public Appointment GetOne(int appointmentID)
        {
            Serialization.Serializer<Appointment> appointmentSerializer = new Serialization.Serializer<Appointment>();
            List<Appointment> appointments = appointmentSerializer.fromCSV("appointments.txt");
            Appointment app = new Appointment();

            foreach (Appointment a in appointments) 
            {
                if (a.Id.Equals(appointmentID)) 
                {
                    app = a;
                    break;
                }
            }
            return app;
        }

        public Boolean Delete(int appointmentID)
        {
            throw new NotImplementedException();
        }
        public static Boolean Create(Appointment appointment)
        {
            Serialization.Serializer<Appointment> appointmentSerializer = new Serialization.Serializer<Appointment>();
            List<Appointment> appointments = new List<Appointment>();
            foreach (Appointment a in appointmentSerializer.fromCSV("appointments.txt")) {
                appointments.Add(a);
            }
            appointments.Add(appointment);
            appointmentSerializer.toCSV("appointments.txt", appointments);
            return true;
        }

        public Boolean Update(Appointment appointment)
        {
            throw new NotImplementedException();
        }

        public String fileName;

    }
}