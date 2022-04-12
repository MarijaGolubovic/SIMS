using System;

namespace SIMS.Model
{
    public class Appointment : Serialization.Serializable
    {
        public DateTime DateAndTime { get; set; }
        public int Id { get; set; }

        public Room Room { get; set; }

        public Patient Patient { get; set; }

        public Doctor Doctor { get; set; }

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
                Patient.Person.JMBG,    //upisujem samo jmbg pacijenta
                Doctor.Person.JMBG
            };
            return csvValues;
        }

        public void fromCSV(string[] values)
        {
            DateAndTime = DateTime.Parse(values[0]);
            Id = int.Parse(values[1]);
            Patient = PatientStorage.GetOne(values[2]);
            Doctor = DoctorStorage.GetByID(values[3]);
        }
    }
}