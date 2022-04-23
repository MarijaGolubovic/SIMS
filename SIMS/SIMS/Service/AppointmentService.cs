using SIMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Service
{
    public class AppointmentService
    {
        private AppointmentStorage storage;

        public AppointmentService() 
        {
            storage = new AppointmentStorage();
        }
        public List<Appointment> GetAll()
        {
            return storage.GetAll();
        }

    }
}
