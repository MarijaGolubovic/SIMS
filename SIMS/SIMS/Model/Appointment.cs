using SIMS.Controller;
using System;
using System.ComponentModel;

namespace SIMS.Model
{
    public class Appointment : Serialization.Serializable, INotifyPropertyChanged
    {
        private DateTime dateAndTime;

        private int id;

        private Room room;

        private Patient patient;

        private Doctor doctor;

        public DateTime DateAndTime
        {
            get { return dateAndTime; }
            set
            {
                if (dateAndTime != value)
                {
                    dateAndTime = value;
                    RaisePropertyChanged("DateAndTime");
                }
            }
        }
        public int Id
        {
            get { return id; }
            set
            {
                if (id != value)
                {
                    id = value;
                    RaisePropertyChanged("Id");
                }
            }
        }

        public Room Room
        {
            get { return room; }
            set
            {
                if (room != value)
                {
                    room = value;
                    RaisePropertyChanged("Room");
                }
            }
        }

        public Patient Patient
        {
            get { return patient; }
            set
            {
                if (patient != value)
                {
                    patient = value;
                    RaisePropertyChanged("Patient");
                }
            }
        }

        public Doctor Doctor
        {
            get { return doctor; }
            set
            {
                if (doctor != value)
                {
                    doctor = value;
                    RaisePropertyChanged("Doctor");
                }
            }
        }

        private readonly PatientController patientController = new PatientController();
        private readonly RoomController roomController = new RoomController();
        private readonly DoctorController doctorController = new DoctorController();

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
            Doctor = doctorController.GetByID(values[4]);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        public Boolean CheckDoctor(Appointment app)
        {
            return doctor.Person.JMBG.Equals(app.Doctor.Person.JMBG);
        }

        public Boolean CheckDoctor(Doctor doctor)
        {
            return doctor.Person.JMBG.Equals(doctor.Person.JMBG);
        }

        public Boolean CheckDoctor(User doctor)
        {
            return doctor.Person.JMBG.Equals(doctor.Person.JMBG);
        }

        public Boolean CheckDateTime(Appointment app)
        {
            return DateAndTime.Equals(app.DateAndTime);
        }

        public Boolean CheckDateTime(DateTime dateTime)
        {
            return DateAndTime.Equals(dateTime);
        }

        public Boolean CheckRoom(Room roomC)
        {
            return Room.Id.Equals(roomC.Id);
        }

        public Boolean CheckRoom(Appointment app)
        {
            return Room.Id.Equals(app.Room.Id);
        }

        public Boolean CheckSpecialization(Specialization specialization)
        {
            return Doctor.Specialization.Name.Equals(specialization.Name);
        }
    }
}