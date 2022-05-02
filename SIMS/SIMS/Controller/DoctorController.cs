using SIMS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Controller
{
    public class DoctorController
    {
        private Service.DoctorService doctorService;

        public DoctorController()
        {
            doctorService = new DoctorService();
        }
        //GetAll
        public static List<SIMS.Model.Doctor> GetAll()
        {
            return DoctorService.GetAll();
        }
        public static SIMS.Model.Doctor GetByID(String jmbg)
        {
            return DoctorService.GetByID(jmbg);
        }

        public static SIMS.Model.Doctor GetByUsername(String username)
        {
            return DoctorService.GetByUsername(username);
        }
    }
}
