using SIMS.Interfaces;
using SIMS.Model;
using SIMS.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;


namespace SIMS.Repository
{
    public class NotificationStorage : INotificationStorage
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
            List<Notificatoin> notifications1 = GetAll();
            foreach (Notificatoin n in notifications1)
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
