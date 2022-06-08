using SIMS.Controller;
using SIMS.Model;
using SIMS.Service;
using System;
using System.Collections.Generic;


namespace SIMS.Model
{
    public class Diagnosis : Serialization.Serializable
    {
        public String DiagnosisText { get; set; }
        public DateTime DateAndTime { get; set; }
        public int AppointmentId { get; set; }

        public Room Room { get; set; }

        public Patient Patient { get; set; }

        public Doctor Doctor { get; set; }

        private readonly PatientController patientController = new PatientController();
        private readonly DoctorController doctorController = new DoctorController();
        private readonly RoomController roomController = new RoomController();

        public Diagnosis(string diagnosisText, DateTime dateAndTime, int id, Room room, Patient patient, Doctor doctor)
        {
            DiagnosisText = diagnosisText;
            DateAndTime = dateAndTime;
            AppointmentId = id;
            Room = room;
            Patient = patient;
            Doctor = doctor;
        }

        public Diagnosis()
        {
        }

        public string[] toCSV()
        {
            string[] csvValues =
            {
                DateAndTime.ToString(),
                AppointmentId.ToString(),
                Room.Id.ToString(),
                Patient.Person.JMBG,
                Doctor.Person.JMBG,
                DiagnosisText
            };
            return csvValues;
        }

        public void fromCSV(string[] values)
        {
            if (values[0] == "")
                return;
            DateAndTime = DateTime.Parse(values[0]);
            AppointmentId = int.Parse(values[1]);
            Room = roomController.GetOne(values[2]);
            Patient = patientController.GetOne(values[3]);
            Doctor = doctorController.GetByID(values[4]);
            DiagnosisText = values[5];
        }
    }
}
