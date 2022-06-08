using SIMS.Interfaces;
using SIMS.Model;
using SIMS.Repository;
using SIMS.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace SIMS.Service
{
    //*******DANIJELA********
    public class EmergencyAppointmentService
    {
        private AppointmentStorage storage;
        private readonly DoctorService doctorService = new DoctorService();
        private readonly RoomService roomService = new RoomService();
        private readonly SugesstedAppointmentsService sugesstedAppointmentsService = new SugesstedAppointmentsService();
        List<Appointment> appointments;
        public EmergencyAppointmentService()
        {
            storage = new AppointmentStorage();
            appointments = storage.GetAll();
        }
        public List<EmergencyAppointmentsDTO> GetEmergencyAppointments(Patient patient, Specialization specialization)
        {
            DateTime dateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, 0, 0);
            dateTime.AddHours(1);
            Model.Doctor doctor = CheckAvaliableDoctor(dateTime, specialization);
            Room room = CheckAvaliableRoom(dateTime);

            if (doctor == null || room == null)
            {
                return FindSuggestionsForPostponingAppointments(dateTime, specialization);
            }
            else
            {
                storage.Create(new Appointment(dateTime, 10, room, patient, doctor));
                return null;
            }
        }
        public SIMS.Model.Doctor CheckAvaliableDoctor(DateTime dateTime, Specialization specialization)
        {
            List<SIMS.Model.Doctor> doctors = doctorService.GetBySpecialization(specialization);

            foreach (SIMS.Model.Doctor doctor in doctors)
            {
                if (!appointments.Exists(app => app.CheckDoctor(doctor) && app.CheckDateTime(dateTime)))
                {
                    return doctor;
                }
            }

            return null;
        }
        public Room CheckAvaliableRoom(DateTime dateTime)
        {
            List<Room> rooms = roomService.GetAll();

            foreach (Room room in rooms)
            {

                if (!appointments.Exists(app => app.CheckDateTime(dateTime) && app.CheckRoom(room)))
                {
                    return room;
                }

            }
            return null;
        }
        public List<EmergencyAppointmentsDTO> FindSuggestionsForPostponingAppointments(DateTime dateTime, Specialization specialization)
        {
            List<EmergencyAppointmentsDTO> postponedAppointments = new List<EmergencyAppointmentsDTO>();
            List<Appointment> appointmentsForPostp = appointments.FindAll(app => app.CheckDateTime(dateTime) && app.CheckSpecialization(specialization));
            Appointment appointment = new Appointment();

            foreach (Appointment app in appointmentsForPostp)
            {
                appointment = sugesstedAppointmentsService.findSuggestedAppointmentsSecretary(app, app.Room.IsRoomForOperation()).OrderBy(x => x.DateAndTime).ToList().FirstOrDefault();
                postponedAppointments.Add(new EmergencyAppointmentsDTO(app.Room, app.Patient, app.Doctor, app.DateAndTime, appointment.Room, appointment.Doctor, appointment.DateAndTime));
            }

            postponedAppointments.Sort((x, y) => DateTime.Compare(x.NewDateAndTime, y.NewDateAndTime));

            return postponedAppointments;
        }
        public Boolean ReschedulingAppointments(Appointment emergency, Appointment oldAppointment, Appointment newAppointment)
        {

            storage.DeleteApp(oldAppointment.DateAndTime, oldAppointment.Room.Id);
            if (CheckAppointment(newAppointment) || CheckAppointment(emergency))
                return false;
            storage.Create(emergency);
            storage.Create(newAppointment);
            return true;
        }
        public Boolean CheckAppointment(Appointment appointment)
        {
            return appointments.Exists(app => (app.CheckDateTime(appointment) && app.CheckRoom(appointment)) || (app.CheckDoctor(appointment) && app.CheckDateTime(appointment)));
        }
    }
}
