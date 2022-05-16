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
        private readonly DoctorService doctorService = new DoctorService();
        private readonly OccupacyRoomService occupacyRoomService = new OccupacyRoomService();
        private List<Appointment> suggestedAppointments = new List<Appointment>();
        private List<Appointment> allAppointments = AppointmentStorage.GetAll();
        private List<Appointment> rangeList = new List<Appointment>();

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

        public bool Create(Appointment appointment, RoomOccupacy roomOccupacy)
        {
            occupacyRoomService.Create(roomOccupacy);
            return storage.Create(appointment);
        }

        public bool CheckIfAvailable(AppointmentForPatientDTO appointmentDTO)
        {
            bool availability = true;
            foreach (Appointment a in allAppointments)
            {
                if (a.DateAndTime.Equals(appointmentDTO.DateTime))
                {
                    if (a.Doctor.Username.Equals(appointmentDTO.Doctor.Username))
                    {
                        availability = false;
                    }
                }
            }
            return availability;
        }

        public int GenerateAppointmentID()
        {
            Random rnd = new Random();
            int id = rnd.Next(0, 1000);

            return id;
        }

        public DateTime FormStartDateTime(DateTime dateTime)
        {
            string date = dateTime.ToString().Split(' ')[0];
            DateTime tmp = DateTime.Parse(date + " " + "08:00");
            return tmp;
        }

        public List<Appointment> PotentialAppointmentsByDoctor(AppointmentForPatientDTO appointmentDTO)
        {
            List<Appointment> potentialAppointments = new List<Appointment>();
            for (int i = 0; i<= 5; i++)
            {
                for (int j = 0; j<= 16; j++) 
                {
                    Room room = FindRoomForAppointment(appointmentDTO);
                    Appointment appointment = new Appointment(FormStartDateTime(appointmentDTO.DateTime).AddMinutes(j*30).AddDays(i), GenerateAppointmentID(), room, patientService.GetOne(appointmentDTO.User.Person.JMBG), appointmentDTO.Doctor);
                    potentialAppointments.Add(appointment);
                }
            }

            return potentialAppointments;
        }

        public List<Appointment> PotentialAppointmentsByDate(AppointmentForPatientDTO appointmentDTO)
        {
            List<Appointment> potentialAppointments = new List<Appointment>();
            foreach (Model.Doctor d in doctorService.GetAll())
            {
                for (int j = 0; j <= 16; j++)
                {
                    Room room = FindRoomForAppointment(appointmentDTO);
                    Appointment appointment = new Appointment(FormStartDateTime(appointmentDTO.DateTime).AddMinutes(j * 30), GenerateAppointmentID(), room, patientService.GetOne(appointmentDTO.User.Person.JMBG), d);
                    potentialAppointments.Add(appointment);
                }
            }
            return potentialAppointments;
        }

        public List<Appointment> FindSuggestedAppointments(AppointmentForPatientDTO appointmentDTO)
        {
            List<Appointment> suggestedAppointments = new List<Appointment>();
            if (appointmentDTO.Priority)
            {
                suggestedAppointments = PotentialAppointmentsByDoctor(appointmentDTO);
            }
            else
            {
                suggestedAppointments = PotentialAppointmentsByDate(appointmentDTO);
            }
            foreach (Appointment tmp1 in GetAll())
            {
                foreach (Appointment tmp2 in suggestedAppointments)
                {
                    if (tmp1.DateAndTime.Equals(tmp2.DateAndTime))
                    {
                        if (tmp1.Doctor.Equals(tmp2.Doctor))
                        {
                            suggestedAppointments.Remove(tmp2);
                        }
                    }
                }
            }

            return suggestedAppointments;
        }

        public RoomOccupacy FormRoomOccupacyFromAppointment(Appointment appointment)
        {
            RoomOccupacy roomOccupacy = new RoomOccupacy(appointment.Room.Id, appointment.DateAndTime, appointment.DateAndTime.AddMinutes(30), "appointment");
            return roomOccupacy;
        }

        public Room FindRoomForAppointment(AppointmentForPatientDTO appointmentDTO)
        {
            List<Room> examinationRooms = roomService.GetByType(RoomType.EXAMINATION_ROOM);
            List<RoomOccupacy> roomOccupacies = new List<RoomOccupacy>();
            List<RoomOccupacy> allRoomOccupacies = occupacyRoomService.GetAll();
            foreach (Room r in examinationRooms)
            {
                roomOccupacies.Add(new RoomOccupacy(r.Id,appointmentDTO.DateTime,appointmentDTO.DateTime.AddMinutes(30),"appointment"));
            }            

            for (int i= 0; i< roomOccupacies.Count; i++)
            {
                foreach (RoomOccupacy ro in allRoomOccupacies)
                {
                    if (roomOccupacies[i].IDRoom == ro.IDRoom)
                    {
                        if ((DateTime.Compare(roomOccupacies[i].Begin, ro.Begin) <= 0) && (DateTime.Compare(ro.End, roomOccupacies[i].End) <= 0))
                        {
                            roomOccupacies.Remove(roomOccupacies[i]);
                        }
                    }
                }
            }
            Room room = roomService.GetOne(roomOccupacies[0].IDRoom);
            return room;
        }

        public Boolean Delete(int appointmentID)
        {
            return storage.Delete(appointmentID);
        }

        public Boolean Delete(int appointmentID, RoomOccupacy room)
        {
            occupacyRoomService.Delete(room);
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
