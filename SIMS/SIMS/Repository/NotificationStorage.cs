using System;
using System.Collections.Generic;
using SIMS.Model;


namespace SIMS.Repository
{
    public class NotificationStorage
    {
        private PatientStorage patientStorage = new PatientStorage();

        public List<Notificatoin> GetAll()
        {
            Serialization.Serializer<Notificatoin> notificationSerializer = new Serialization.Serializer<Notificatoin>();
            List<Notificatoin> notifications = notificationSerializer.fromCSV("notification.txt");

            return notifications;
        }
        public List<Notificatoin> GetAllForPatient(String jmbg)
        {
            List<Notificatoin> notifications = new List<Notificatoin>();
            foreach (Notificatoin n in GetAll())
            {
                if (n.Patient.JMBGP == jmbg)
                {
                    notifications.Add(n);
                }
            }

            return notifications;
        }

        public Boolean Create(Notificatoin notification)
        {
            Serialization.Serializer<Notificatoin> NotificationSerializer = new Serialization.Serializer<Notificatoin>();
            List<Notificatoin> Notifications = new List<Notificatoin>();
            foreach (Notificatoin tmp in NotificationSerializer.fromCSV("notification.txt"))
            {
                Notifications.Add(tmp);
            }
            Notifications.Add(notification);
            NotificationSerializer.toCSV("notification.txt", Notifications);

            return true;
        }
    }
}
