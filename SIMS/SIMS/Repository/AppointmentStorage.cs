using SIMS.Interfaces;
using SIMS.Model;
using SIMS.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;


namespace SIMS.Repository
{
    public class AppointmentStorage : IAppointmentStorage
    {
        public AppointmentStorage()
        {
        }
        public List<Appointment> GetAll()
        {
            Serialization.Serializer<Appointment> appointmentSerializer = new Serialization.Serializer<Appointment>();
            List<Appointment> Appointments = appointmentSerializer.fromCSV("appointments.txt");
            return Appointments;
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
            List<Appointment> appointments = GetAll();

            foreach (Appointment a in appointments)
            {
                if (a.Id.Equals(appointmentID))
                {
                    appointments.Remove(a);
                    break;
                }
            }

            Serialization.Serializer<Appointment> appointmentSerializer = new Serialization.Serializer<Appointment>();
            appointmentSerializer.toCSV("appointments.txt", appointments);
            return true;

        }
        public Boolean Create(Appointment appointment)
        {
            Serialization.Serializer<Appointment> appointmentSerializer = new Serialization.Serializer<Appointment>();
            List<Appointment> appointments = new List<Appointment>();
            foreach (Appointment a in appointmentSerializer.fromCSV("appointments.txt"))
            {
                appointments.Add(a);
            }
            appointments.Add(appointment);
            appointmentSerializer.toCSV("appointments.txt", appointments);
            return true;
        }

        public Boolean DeleteApp(DateTime dateTime, String roomId)
        {
            List<Appointment> appointments = GetAll();
            appointments.Remove(appointments.Find(a => a.DateAndTime == dateTime && a.Room.Id.Equals(roomId)));

            Serialization.Serializer<Appointment> appointmentSerializer = new Serialization.Serializer<Appointment>();
            appointmentSerializer.toCSV("appointments.txt", appointments);
            return true;

        }

        public String fileName;

    }
}