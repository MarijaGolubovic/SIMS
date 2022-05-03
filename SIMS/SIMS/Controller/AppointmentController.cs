using SIMS.Model;
using SIMS.Service;
using System;
using System.Collections.Generic;

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

    }
}
