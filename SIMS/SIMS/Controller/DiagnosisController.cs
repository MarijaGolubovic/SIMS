using SIMS.Model;
using SIMS.Service;
using System;
using System.Collections.Generic;


namespace SIMS.Controller
{
    public class DiagnosisController
    {
        public DiagnosisController() { }

        private readonly DiagnosisService service = new DiagnosisService();

        public Boolean Create(Diagnosis diagnosisForAdd)
        {
            return service.Create(diagnosisForAdd);
        }
        public List<Diagnosis> GetByPatient(Patient patient)
        {
            return service.GetByPatient(patient);
        }
        public Diagnosis GetOne(int appointmentID)
        {
            return service.GetOne(appointmentID);
        }
    }
}
