using SIMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Interfaces
{
    internal interface INotificationStorage
    {
        public List<Notificatoin> GetAll();
        public List<Notificatoin> GetAllForPatient(String jmbg);
        public Boolean Create(Notificatoin notification);
    }
}
