using SIMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Interfaces
{
    internal interface IPatientStorage
    {
        public List<Patient> GetAll();
        public Patient GetOne(String jmbg);
        public Boolean Create(Patient patient);
        public Boolean Update(String jmbg, AccountStatus accountStatus);
        public Boolean UpdateJMBG(String jmbgOld, String jmbgNew);
    }
}
