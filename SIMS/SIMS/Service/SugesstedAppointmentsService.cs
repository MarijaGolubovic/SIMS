using SIMS.Interfaces;
using SIMS.Model;
using SIMS.Repository;
using SIMS.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SIMS.Service
{
    //*******DANIJELA********
    public class SugesstedAppointmentsService
    {
        private IAppointmentStorage storage;
        private RoomService roomService { get; set; }
        List<Appointment> appointments;


        public SugesstedAppointmentsService()
        {
            storage = new AppointmentStorage();
            roomService = new RoomService();
            appointments = storage.GetAll();
        }
        //*******DANIJELA********
        public List<Appointment> findSuggestedAppointmentsSecretary(Appointment appointment, Boolean operation)
        {
            List<Appointment> suggestedAppointments = new List<Appointment>();
            int i = 0;
            while (i < appointments.Count)
            {
                if (appointments.Exists(app => app.CheckDoctor(appointment) && app.CheckDateTime(appointment)))
                {
                    appointment.DateAndTime = appointment.DateAndTime.AddHours(1);
                    i = 0;
                }
                else
                {
                    if (avaiableRooms(operation, appointment.DateAndTime).Count != 0)
                    {
                        foreach (Room room in avaiableRooms(operation, appointment.DateAndTime))
                        {
                            suggestedAppointments.Add(new Appointment(appointment.DateAndTime, 10, room, appointment.Patient, appointment.Doctor));
                        }
                        i = appointments.Count;
                    }
                }
            }
            return suggestedAppointments;
        }

        public List<Room> avaiableRooms(Boolean operation, DateTime dateTime)
        {
            List<Room> avaiableRooms = new List<Room>();
            List<Room> rooms = roomService.GetAll();
            foreach (Room room in rooms)
            {
                if (operation)
                {
                    if (room.IsRoomForOperation())
                    {
                        if (!appointments.Exists(app => app.CheckDateTime(dateTime) && app.CheckRoom(room)))
                        {
                            avaiableRooms.Add(room);
                        }
                    }
                }
                else
                {
                    if (room.IsRoomForExamination())
                    {
                        if (!appointments.Exists(app => app.CheckDateTime(dateTime) && app.CheckRoom(room)))
                        {
                            avaiableRooms.Add(room);
                        }
                    }
                }
            }
            return avaiableRooms;
        }

    }
}
