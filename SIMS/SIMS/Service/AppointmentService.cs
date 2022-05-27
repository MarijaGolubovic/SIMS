using System;
using System.Collections.Generic;
using System.Linq;
using SIMS.Model;
using SIMS.Repository;

namespace SIMS.Service
{
    public class AppointmentService
    {
        private AppointmentStorage storage;
        private RoomService roomService { get; set; }
        private readonly PatientService patientService = new PatientService();
        private readonly DoctorService doctorService = new DoctorService();

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
            foreach (Appointment a in allAppointments)
            {
                if (a.Doctor.Person.JMBG.Equals(doctorId))
                {
                    String date1 = a.DateAndTime.ToString().Split(' ')[0];
                    if (date.Equals(date1))
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
            while (i < appointments.Count)
            {

                if (appointments.Exists(a => (a.Doctor.Person.JMBG.Equals(appointment.Doctor.Person.JMBG) && (a.DateAndTime.Equals(appointment.DateAndTime)))))
                {
                    appointment.DateAndTime = appointment.DateAndTime.AddHours(1);
                    i = 0;
                }
                else
                {
                    if (avaiableRoom(operation, appointment.DateAndTime).Count != 0)
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

        public List<Room> avaiableRoom(Boolean operation, DateTime dateTime)
        {
            List<Room> room = new List<Room>();
            List<Room> rooms = roomService.GetAll();
            List<Appointment> appointments = GetAll();

            foreach (Room r in rooms)
            {
                if (operation)
                {
                    if (r.Type == RoomType.OPPERATING_ROOM)
                    {
                        if (!appointments.Exists(a => a.DateAndTime == dateTime && a.Room.Id.Equals(r.Id)))
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

        public List<EmergencyAppointmentsDTO> GetEmergencyAppointments(Patient patient, Specialization specialization)
        {
            DateTime dateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, 0, 0);
            dateTime.AddHours(1);
            Model.Doctor doctor = CheckAvaliableDoctor(dateTime, specialization);
            Room room = CheckAvaliableRoom(dateTime);

            if (doctor == null || room == null)
            {
                return FindSuggestionsForPostponingAppointments(dateTime, specialization);
            }
            else
            {
                Create(new Appointment(dateTime, 10, room, patient, doctor));
                return null;
            }
        }

        public SIMS.Model.Doctor CheckAvaliableDoctor(DateTime dateTime, Specialization specialization)
        {
            List<Appointment> appointments = GetAll();
            List<SIMS.Model.Doctor> doctors = doctorService.GetBySpecialization(specialization);

            foreach (SIMS.Model.Doctor d in doctors)
            {
                if (!appointments.Exists(a => a.Doctor.Person.JMBG.Equals(d.Person.JMBG) && a.DateAndTime == dateTime))
                {
                    return d;
                }
            }

            return null;
        }

        public Room CheckAvaliableRoom(DateTime dateTime)
        {
            List<Room> rooms = roomService.GetAll();
            List<Appointment> appointments = GetAll();

            foreach (Room r in rooms)
            {

                if (!appointments.Exists(a => a.DateAndTime == dateTime && a.Room.Id.Equals(r.Id)))
                {
                    return r;
                }

            }
            return null;
        }

        public List<EmergencyAppointmentsDTO> FindSuggestionsForPostponingAppointments(DateTime dateTime, Specialization specialization)
        {
            List<EmergencyAppointmentsDTO> postponedAppointments =new List<EmergencyAppointmentsDTO>();
            List<Appointment> appointments = GetAll();
            List<Appointment> appointmentsForPostp = appointments.FindAll(a => a.DateAndTime == dateTime && a.Doctor.Specialization.Name.Equals(specialization.Name));
            Appointment appointment = new Appointment();

            foreach (Appointment a in appointmentsForPostp)
            {
                appointment = findSuggestedAppointmentsSecretary(a.Doctor, a.Patient, a.DateAndTime, true, CheckRoomType(a.Room)).OrderBy(x=>x.DateAndTime).ToList().FirstOrDefault();
                postponedAppointments.Add(new EmergencyAppointmentsDTO(a.Room,a.Patient,a.Doctor,a.DateAndTime,appointment.Room,appointment.Doctor,appointment.DateAndTime));
            }

            postponedAppointments.Sort((x, y) => DateTime.Compare(x.NewDateAndTime, y.NewDateAndTime));

          return postponedAppointments;
        }

        public Boolean CheckRoomType(Room room)
        {
            if (room.Type == RoomType.OPPERATING_ROOM)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean ReschedulingAppointments(Appointment emergency, Appointment oldTermin, Appointment newTermin)
        {

            storage.DeleteApp(oldTermin.DateAndTime, oldTermin.Room.Id);
            if (CheckAppointment(newTermin) || CheckAppointment(emergency))
                return false;
            storage.Create(emergency);
            storage.Create(newTermin);
            return true;
        }

        public Boolean CheckAppointment(Appointment appointment)
        {
            List<Appointment> appointments = GetAll();
            return appointments.Exists(a => ((a.DateAndTime == appointment.DateAndTime) && (a.Room.Id.Equals(appointment.Room.Id))) || ((a.Doctor.Username.Equals(appointment.Doctor.Username) && (a.DateAndTime == appointment.DateAndTime))));
        }


    }
}
