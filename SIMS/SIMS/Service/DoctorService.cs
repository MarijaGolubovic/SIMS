using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Service
{
    public class DoctorService
    {
        private Repository.DoctorStorage doctorStorage;

        public DoctorService()
        {
            doctorStorage = new Repository.DoctorStorage();
        }

        public static List<SIMS.Model.Doctor> GetAll()
        {
            return Repository.DoctorStorage.GetAll();
        }

        public static SIMS.Model.Doctor GetByID(String jmbg)
        {
            return Repository.DoctorStorage.GetByID(jmbg);
        }

        public static SIMS.Model.Doctor GetByUsername(String username)
        {
            return Repository.DoctorStorage.GetByUsername(username);
        }
    }
}
