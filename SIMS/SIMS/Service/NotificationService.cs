using System;
using System.Collections.Generic;
using SIMS.Model;

namespace SIMS.Service
{
    public class NotificationService
    {
        private Repository.NotificationStorage notificationStorage = new Repository.NotificationStorage();

        public List<Notificatoin> GetAllForPatient(String jmbg)
        {
            return notificationStorage.GetAllForPatient(jmbg);
        }

    }
}
