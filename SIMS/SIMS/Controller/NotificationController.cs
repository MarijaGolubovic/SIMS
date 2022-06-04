using System;
using System.Collections.Generic;
using SIMS.Model;
using SIMS.Service;

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
    }
}
