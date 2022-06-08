using SIMS.Model;
using SIMS.Service;
using System;
using System.Collections.Generic;

namespace SIMS.Model
{
    public class EmergencyAppointmentsDTO
    {
        public Room Room { get; set; }

        public Patient Patient { get; set; }

        public Doctor Doctor { get; set; }

        public DateTime DateAndTime { get; set; }

        public Room NewRoom { get; set; }

        public Doctor NewDoctor { get; set; }

        public DateTime NewDateAndTime { get; set; }

        public EmergencyAppointmentsDTO(Room room, Patient patient, Doctor doctor, DateTime dateAndTime, Room newRoom, Doctor newDoctor, DateTime newDateAndTime)
        {
            Room = room;
            Patient = patient;
            Doctor = doctor;
            DateAndTime = dateAndTime;
            NewRoom = newRoom;
            NewDoctor = newDoctor;
            NewDateAndTime = newDateAndTime;
        }
    }
}
