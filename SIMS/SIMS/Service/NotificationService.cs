using SIMS.Interfaces;
using SIMS.Model;
using SIMS.Repository;
using SIMS.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SIMS.Service
{
    public class NotificationService
    {
        private INotificationStorage notificationStorage = new Repository.NotificationStorage();

        public List<Notificatoin> GetAllForPatient(String jmbg)
        {
            return notificationStorage.GetAllForPatient(jmbg);
        }

        internal bool Create(Notificatoin notificatoin)
        {
            return notificationStorage.Create(notificatoin);
        }
    }
}
