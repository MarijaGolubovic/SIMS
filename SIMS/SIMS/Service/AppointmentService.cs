using System;
using System.Collections.Generic;
using SIMS.Model;
using SIMS.Repository;

namespace SIMS.Service
{
    public class AppointmentService
    {
        private AppointmentStorage storage;
        private RoomService roomService { get; set; }
        private readonly PatientService patientService = new PatientService();

        public AppointmentService()
        {
            storage = new AppointmentStorage();
            roomService = new RoomService();
        }
        public List<Appointment> GetAll()
        {
            return AppointmentStorage.GetAll();
        }

        public Appointment GetOne(int appointmentID)
        {
            return storage.GetOne(appointmentID);
        }

        public Boolean Create(Appointment appointment)
        {
            return storage.Create(appointment);
        }

        public List<Appointment> findSuggestedAppointments(Model.Doctor doctorTmp, bool doctorPriority, bool appointemntPriority, DateTime dateTimeTmp)
        {
            List<Appointment> suggestedAppointments = new List<Appointment>();
            List<Appointment> allAppointments = AppointmentStorage.GetAll();
            List<Appointment> rangeList = new List<Appointment>();

            Appointment appointment = new Appointment(dateTimeTmp, 1, roomService.GetOne("o1"), patientService.GetOne("2212010103158"), doctorTmp);

            //petlja koja provjerava da li je zeljeni termin slobodan
            //isAvailable()
            bool free = true;
            foreach (Appointment a in allAppointments)
            {
                if (a.DateAndTime.Equals(dateTimeTmp))
                {
                    if (a.Doctor.Username.Equals(doctorTmp.Username))
                    {
                        free = false;
                    }
                }
            }
            if (free == true)
            {
                suggestedAppointments.Add(appointment);
                storage.Create(appointment);


                return suggestedAppointments;
            }
            else
            {
                //napisati metodu koja trazi poprioritetima termine
                //suggestedAppointments()  
                if (doctorPriority == true)  //ako je doktor prioritet
                {
                    for (int i = 1; i <= 5; i++)
                    {
                        //ubacujem skorasnje termine koje cu provjeriti da li su slobodni
                        Appointment tmp = new Appointment(dateTimeTmp.AddDays(i), 1, roomService.GetOne("o1"), patientService.GetOne("2212010103158"), doctorTmp);
                        rangeList.Add(tmp);
                    }
                    bool free1 = true;
                    foreach (Appointment a in allAppointments)
                    {
                        foreach (Appointment r in rangeList)
                        {
                            if (a.DateAndTime.Equals(r.DateAndTime))
                            {
                                if (a.Doctor.Equals(r.Doctor))
                                {
                                    rangeList.Remove(r);
                                }
                            }
                        }
                    }
                    return rangeList;                 //u rangeList ostanu termini koje treba ponuditi
                }
                else                        // ako je termin prioritet
                {

                }

            }
            return suggestedAppointments;
        }

        public Boolean Delete(int appointmentID)
        {
            return storage.Delete(appointmentID);
        }

        public List<DateTime> getTimesOfDoctorAppointments(String doctorId, DateTime dateOfAppointment)
        {
            List<DateTime> doctorAppointments = new List<DateTime>();
            List<Appointment> allAppointments = GetAll();
            String date = dateOfAppointment.ToString().Split(' ')[0];
            foreach(Appointment a in allAppointments)
            {
                if (a.Doctor.Person.JMBG.Equals(doctorId)) 
                {
                    String date1 = a.DateAndTime.ToString().Split(' ')[0];
                    if(date.Equals(date1))
                        doctorAppointments.Add(a.DateAndTime);
                }
            }

            return doctorAppointments;
        }

        public List<Appointment> findSuggestedAppointmentsSecretary(Model.Doctor doctor, Patient patient, DateTime dateTime, Boolean doctorPriority, Boolean operation)
        {
            List<Appointment> suggestedAppointments = new List<Appointment>();
            List<Appointment> appointments = GetAll();
            Appointment appointment = new Appointment(dateTime, 10, new Room(), patient, doctor);

            int i = 0;
            while (i<appointments.Count)
            {

               if (appointments.Exists(a => (a.Doctor.Person.JMBG.Equals(appointment.Doctor.Person.JMBG) && (a.DateAndTime.Equals(appointment.DateAndTime)))))
                {
                    appointment.DateAndTime=appointment.DateAndTime.AddHours(1);
                    i = 0;
                } else
                {
                    if(avaiableRoom(operation, appointment.DateAndTime).Count != 0)
                    {
                        foreach (Room r in avaiableRoom(operation, appointment.DateAndTime))
                        {
                            suggestedAppointments.Add(new Appointment(appointment.DateAndTime, 10, r, appointment.Patient, appointment.Doctor));
                        }

                            i = appointments.Count;

                    }
                }
            }
            return suggestedAppointments;
        }

        public List<Room> avaiableRoom (Boolean operation, DateTime dateTime)
        {
            List<Room> room = new List<Room>();
            List<Room> rooms = roomService.GetAll();
            List<Appointment> appointments = GetAll();

            foreach (Room r in rooms)
            {
                if(operation)
                {
                    if (r.Type==RoomType.OPPERATING_ROOM)
                    {
                        if(!appointments.Exists(a=> a.DateAndTime == dateTime && a.Room.Id.Equals(r.Id)))
                        {
                            room.Add(r);
                        }
                    }
                }
                else
                {
                    if (r.Type == RoomType.EXAMINATION_ROOM)
                    {
                        if (!appointments.Exists(a => a.DateAndTime == dateTime && a.Room.Id.Equals(r.Id)))
                        {
                            room.Add(r);
                        }
                    }
                }
            }


            return room;
        }

        public Boolean DeleteApp(DateTime dateTime, String roomId)
        {
            return storage.DeleteApp(dateTime, roomId);
        }

    }
}
