using SIMS.Controller;
using SIMS.Model;
using SIMS.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SIMS.Model
{
    public class Notificatoin : INotifyPropertyChanged, Serialization.Serializable
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private DateTime notificationDateTime;
        private String details;
        private Patient patient;

        public Patient Patient { get; set; }

        public DateTime NotificationDateTime
        {
            get
            {
                return notificationDateTime;
            }
            set
            {
                notificationDateTime = value;
                OnPropertyChanged("NotificationDateTime");
            }
        }
        public String Details
        {
            get
            {
                return details;
            }
            set
            {
                details = value;
                OnPropertyChanged("Details");
            }
        }

        public Notificatoin(DateTime notificationDateTime, String details, Patient patient)
        {
            Details = details;
            NotificationDateTime = notificationDateTime;
            Patient = patient;
        }

        public Notificatoin()
        {

        }
        public string[] toCSV()
        {
            string[] csvValues =
            {
                Patient.JMBGP,
                NotificationDateTime.ToString(),
                Details
            };
            return csvValues;
        }

        public void fromCSV(string[] values)
        {
            if (values[0] == "")
                return;
            PatientController pc = new PatientController();
            Patient = pc.GetOne(values[0]);
            NotificationDateTime = DateTime.Parse(values[1]);
            Details = values[2];
        }
    }
}
