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

        public List<Patient> GetAllActiv()
        {
            return patientService.GetAllActiv();
        }

        public List<Patient> GetAllBlock()
        {
            return patientService.GetAllBlock();
        }

        public void Update(Patient patient)
        {
            patientService.Update(patient.Person.JMBG, patient.AccountStatus);
        }

        public Boolean Create (Patient patient)
        {
            return patientService.Create(patient);
        }

        public Boolean UpdateJMBG(String jmbgOld, String jmbgNew)
        {
            return patientService.UpdateJMBG(jmbgOld, jmbgNew);
        }


    }
}
