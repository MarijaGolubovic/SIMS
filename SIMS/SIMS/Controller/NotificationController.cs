using SIMS.Model;
using SIMS.Service;
using System;
using System.Collections.Generic;


namespace SIMS.Controller
{
    public class NotificationController
    {
        private readonly NotificationService notificationService = new NotificationService();
        public NotificationController()
        {
        }

        public List<Notificatoin> GetAllForPatient(String jmbg)
        {
            return notificationService.GetAllForPatient(jmbg);
        }

        public bool Create(Notificatoin notificatoin)
        {
            return notificationService.Create(notificatoin);
        }
    }
}
