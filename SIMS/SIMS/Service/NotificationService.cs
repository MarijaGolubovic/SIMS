using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
