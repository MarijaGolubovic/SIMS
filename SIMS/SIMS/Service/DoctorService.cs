using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Service
{
    public class DoctorService
    {
        private Repository.DoctorStorage doctorStorage = new Repository.DoctorStorage();

        public DoctorService()
        {
            doctorStorage = new Repository.DoctorStorage();
        }

        public List<SIMS.Model.Doctor> GetAll()
        {
            return doctorStorage.GetAll();
        }

        public SIMS.Model.Doctor GetByID(String jmbg)
        {
            return doctorStorage.GetByID(jmbg);
        }

        public SIMS.Model.Doctor GetByUsername(String username)
        {
            return doctorStorage.GetByUsername(username);
        }
    }
}
