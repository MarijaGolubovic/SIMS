using System;
using System.Collections.Generic;
using System.Windows;
using SIMS.Model;
using SIMS.Service;


namespace SIMS.Controller
{
    public class AppointmentController
    {

        private readonly AppointmentService appointmentService = new AppointmentService();
        private readonly PatientController patientController = new PatientController();
        private readonly OccupacyRoomService occupacyRoomService = new OccupacyRoomService();
        private readonly SugesstedAppointmentsService sugesstedAppointmentsService = new SugesstedAppointmentsService();
        private readonly EmergencyAppointmentService emergencyAppointmentService = new EmergencyAppointmentService();



        public AppointmentController()
        {
        }

        public void EditRoom(int appointmentId, Room room)
        {
            appointmentService.EditRoom(appointmentId, room);
        }
        public List<AppointmentsForDoctorDTO> GetAppointmentsForDoctor()
        {
            List<AppointmentsForDoctorDTO> appointmentsForDoctorDTOs = new List<AppointmentsForDoctorDTO>();
            List<Appointment> appointments = appointmentService.GetAll();

            foreach (Appointment a in appointments)
            {
                if (a.Doctor.Person.JMBG.Equals(ViewModel.Doctor.MainWindowViewModel.LoggedInUser.Person.JMBG))
                {
                    String name = a.Patient.Person.Name;
                    String surname = a.Patient.Person.Surname;
                    String[] array = a.DateAndTime.Date.ToString().Split(' ');
                    String date = array[0];
                    String time = a.DateAndTime.TimeOfDay.ToString();
                    String roomId = a.Room.Id;
                    String doctorId = a.Doctor.Person.JMBG;
                    AppointmentsForDoctorDTO pom = new AppointmentsForDoctorDTO(a.Id, name, surname, date, time, roomId, doctorId);

                    appointmentsForDoctorDTOs.Add(pom);
                }
            }

            return appointmentsForDoctorDTOs;
        }

        public List<AppointmentsForSecretaryDTO> GetAppointmentsForSecretary(DateTime dateTime)
        {
            List<AppointmentsForSecretaryDTO> appointmentsForSecretaryDTOs = new List<AppointmentsForSecretaryDTO>();
            List<Appointment> appointments = appointmentService.GetAll();

            foreach (Appointment a in appointments)
            {
                if (a.DateAndTime.Date == dateTime.Date)
                {
                    String NameSurnameDoctor = a.Doctor.Person.Name + " " + a.Doctor.Person.Surname;
                    String NameSurnamePatient = a.Patient.Person.Name + " " + a.Patient.Person.Surname;
                    String date = a.DateAndTime.ToShortDateString();
                    String time = a.DateAndTime.ToShortTimeString();
                    String roomId = a.Room.Id;
                    AppointmentsForSecretaryDTO pom = new AppointmentsForSecretaryDTO(a.Id, NameSurnameDoctor, NameSurnamePatient, date, time, roomId);

                    appointmentsForSecretaryDTOs.Add(pom);

                }
            }

            return appointmentsForSecretaryDTOs;
        }

        public Appointment GetOne(int appointmentID)
        {
            return appointmentService.GetOne(appointmentID);
        }

        public Boolean Create(Appointment appointment)
        {
            return appointmentService.Create(appointment);
        }

        public bool Create(Appointment appointment, RoomOccupacy roomOccupacy)
        {
            return appointmentService.Create(appointment, roomOccupacy);
        }

        public int GenerateAppointmentID()
        {
            return appointmentService.GenerateAppointmentID();
        }

        public RoomOccupacy FormRoomOccupacyFromAppointment(Appointment appointment)
        {
            return appointmentService.FormRoomOccupacyFromAppointment(appointment);
        }

        public Room FindRoomForAppointment(AppointmentForPatientDTO appointmentDTO)
        {
            return appointmentService.FindRoomForAppointment(appointmentDTO);
        }

        public bool CheckIfAvailable(AppointmentForPatientDTO appointmentDTO)
        {
            return appointmentService.CheckIfAvailable(appointmentDTO);
        }

        public List<Appointment> FindSuggestedAppointments(AppointmentForPatientDTO appointmentDTO)
        {
            return appointmentService.FindSuggestedAppointments(appointmentDTO);
        }

        public bool CheckIfDateIsValid(DateTime date)
        {
            if (DateTime.Compare(DateTime.Now, date) > 0)
            {
                MessageBox.Show("Nije moguce zakazati termin u proslosti!");
                return false;
            }
            return true;
        }

        public bool CheckIfDateIsValidForDoctor(DateTime date)
        {
            if (DateTime.Compare(DateTime.Now, date) > 0)
            {
                return false;
            }
            return true;
        }

        public bool CheckIfDateIsValidForEdit(DateTime old, DateTime chosen)
        {
            if (DateTime.Compare(DateTime.Now, chosen) > 0)
            {
                MessageBox.Show("Nije moguce zakazati termin u proslosti!");
                return false;
            }
            if ((chosen - old).TotalDays > 7)
            {
                MessageBox.Show("Termin pregleda je moguce pomjeriti do 7 dana!");
                return false;
            }
            return true;
        }


        public Boolean Delete(int appointmentID)
        {
            return appointmentService.Delete(appointmentID);
        }

        public Boolean Delete(int appointmentID, RoomOccupacy roomOccupacy)
        {
            occupacyRoomService.Delete(roomOccupacy);
            return appointmentService.Delete(appointmentID);
        }

        public List<DateTime> getTimesOfDoctorAppointments(String doctorId, DateTime dateOfAppointment)
        {
            return appointmentService.getTimesOfDoctorAppointments(doctorId, dateOfAppointment);
        }

        public List<Appointment> findSuggestedAppointmentsSecretary(Model.Doctor doctor, Patient patient, DateTime dateTime, Boolean doctorPriority, Boolean operation)
        {
            return sugesstedAppointmentsService.findSuggestedAppointmentsSecretary(new Appointment(dateTime, 10, new Room(), patient, doctor), operation);
        }
        public Boolean DeleteApp(AppointmentsForSecretaryDTO appointment)
        {

            return appointmentService.DeleteApp(DateTime.Parse(appointment.Date + " " + appointment.Time), appointment.roomId);
        }

        public List<EmergencyAppointmentsDTO> GetEmergencyAppointments(Patient patient, Specialization specialization)
        {
            return emergencyAppointmentService.GetEmergencyAppointments(patient, specialization);
        }

        public Boolean ReschedulingAppointments(Patient urgentPatient, EmergencyAppointmentsDTO rescheduledAppointment)
        {
            Appointment emergency = new Appointment(rescheduledAppointment.DateAndTime, 10, rescheduledAppointment.Room, urgentPatient, rescheduledAppointment.Doctor);
            Appointment oldTermin = new Appointment(rescheduledAppointment.DateAndTime, 10, rescheduledAppointment.Room, rescheduledAppointment.Patient, rescheduledAppointment.Doctor);
            Appointment newTermin = new Appointment(rescheduledAppointment.NewDateAndTime, 10, rescheduledAppointment.NewRoom, rescheduledAppointment.Patient, rescheduledAppointment.NewDoctor);
            return emergencyAppointmentService.ReschedulingAppointments(emergency, oldTermin, newTermin);
        }

        public List<Room> FindRoomsForEditAppointment(AppointmentsForDoctorDTO appointmentDTO)
        {
            return appointmentService.FindRoomsForEditAppointment(appointmentDTO);
        }
    }
}
