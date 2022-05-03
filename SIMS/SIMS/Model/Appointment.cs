using System;
using SIMS.Controller;

namespace SIMS.Model
{
    public class Appointment : Serialization.Serializable
    {
        public DateTime DateAndTime { get; set; }
        public int Id { get; set; }

        public Room Room { get; set; }

        public Patient Patient { get; set; }

        public Doctor Doctor { get; set; }

        private readonly PatientController patientController = new PatientController();
        private readonly RoomController roomController = new RoomController();

        public Appointment(DateTime dateAndTime, int id, Room room, Patient patient, Doctor doctor)
        {
            this.DateAndTime = dateAndTime;
            this.Id = id;
            this.Room = room;
            Patient = patient;
            Doctor = doctor;
        }

        public Appointment()
        {
        }

        public string[] toCSV()
        {
            string[] csvValues =
            {
                DateAndTime.ToString(),
                Id.ToString(),
                Room.Id.ToString(),
                Patient.Person.JMBG,
                Doctor.Person.JMBG,
            };
            return csvValues;
        }

        public void fromCSV(string[] values)
        {
            if (values[0] == "")
                return;
            DateAndTime = DateTime.Parse(values[0]);
            Id = int.Parse(values[1]);
            Room = roomController.GetOne(values[2]);
            Patient = patientController.GetOne(values[3]);
            Doctor = Repository.DoctorStorage.GetByID(values[4]);
        }
    }
}