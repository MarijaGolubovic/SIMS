using System;
using System.Collections.Generic;
using SIMS.Interfaces;
using SIMS.Model;

namespace SIMS.Service
{
    public class NotificationService
    {
        private INotificationStorage notificationStorage = new Repository.NotificationStorage();

        public List<Notificatoin> GetAllForPatient(String jmbg)
        {
            return notificationStorage.GetAllForPatient(jmbg);
        }

    }
}
