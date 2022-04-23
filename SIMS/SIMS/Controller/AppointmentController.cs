using SIMS.Model;
using SIMS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Controller
{
    public class AppointmentController
    {

        private AppointmentService appointmentService;

        public AppointmentController() 
        {
            appointmentService = new AppointmentService();
        }

        public List<AppointmentsForDoctorDTO> GetAppointmentsForDoctor() 
        {
            List<AppointmentsForDoctorDTO> appointmentsForDoctorDTOs = new List<AppointmentsForDoctorDTO>();
            List<Appointment> appointments = appointmentService.GetAll();

            foreach(Appointment a in appointments) 
            {
                String name = a.Patient.Person.Name;
                String surname = a.Patient.Person.Surname;
                String[] array = a.DateAndTime.Date.ToString().Split(' ');
                String date = array[0];
                String time = a.DateAndTime.TimeOfDay.ToString();
                String roomId = a.Room.Id;
                AppointmentsForDoctorDTO pom = new AppointmentsForDoctorDTO(name, surname, date, time, roomId);

                appointmentsForDoctorDTOs.Add(pom);
            }

            return appointmentsForDoctorDTOs;
        }

    }
}
