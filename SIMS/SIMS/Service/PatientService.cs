using SIMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Service
{
    public class PatientService
    {
        private PatientStorage patientStorage;

        public PatientService() 
        {
            patientStorage = new PatientStorage();
        }

        public List<Patient> GetAll() 
        {
            return patientStorage.GetAll();
        }

        public Patient GetOne(String jmbg) 
        {
            return patientStorage.GetOne(jmbg);
        }
    }
}
