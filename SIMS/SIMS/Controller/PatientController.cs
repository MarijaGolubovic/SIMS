using SIMS.Model;
using SIMS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Controller
{
    public class PatientController
    {
        private readonly PatientService patientService;

        public PatientController()
        { 
            patientService = new PatientService();
        }

        public List<Patient> GetAll()
        {
            return patientService.GetAll();
        }

        public Patient GetOne(String jmbg)
        {
            return patientService.GetOne(jmbg);
        }
    }
}
