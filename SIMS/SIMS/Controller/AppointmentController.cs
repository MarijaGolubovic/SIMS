using System;
using System.Collections.Generic;
using SIMS.Model;
using SIMS.Service;


namespace SIMS.Controller
{
    public class AppointmentController
    {

        private readonly AppointmentService appointmentService = new AppointmentService();
        private readonly PatientController patientController = new PatientController();

        public AppointmentController()
        {
        }

        public List<AppointmentsForDoctorDTO> GetAppointmentsForDoctor()
        {
            List<AppointmentsForDoctorDTO> appointmentsForDoctorDTOs = new List<AppointmentsForDoctorDTO>();
            List<Appointment> appointments = appointmentService.GetAll();

            foreach (Appointment a in appointments)
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

        public List<Appointment> findSuggestedAppointments(Model.Doctor doctorTmp, bool doctorPriority, bool appointemntPriority, DateTime dateTimeTmp)
        {
            //porvjera da li je jedno od polja prioriteta oznaceno
            if (doctorPriority == false && appointemntPriority == false)
            {
                //javi gresku korisniku
            }
            //ovo su sad predlozeni termini
            List<Appointment> suggestedAppointments = appointmentService.findSuggestedAppointments(doctorTmp, doctorPriority, appointemntPriority, dateTimeTmp);
            List<Appointment> createdAppointemnt = new List<Appointment>();
            //ako lista predlozenih termina sadrzi tacno zeljeni termin onda je termin vec kreiran

            return suggestedAppointments;
        }


        
        public Boolean Delete(int appointmentID)
        {
            return appointmentService.Delete(appointmentID);
        }

        public List<DateTime> getTimesOfDoctorAppointments(String doctorId, DateTime dateOfAppointment)
        {
            return appointmentService.getTimesOfDoctorAppointments(doctorId, dateOfAppointment);
        }
    }
}
