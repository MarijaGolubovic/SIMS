using SIMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
