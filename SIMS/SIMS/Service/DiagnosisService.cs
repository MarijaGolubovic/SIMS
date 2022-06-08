using System;
using System.Collections.Generic;
using SIMS.Interfaces;
using SIMS.Model;
using SIMS.Repository;

namespace SIMS.Service
{
    public class DiagnosisService
    {
        public DiagnosisService() { }

        private readonly IDiagnosisStorage storage = new DiagnosisStorage();

        public Boolean Create(Diagnosis diagnosisForAdd)
        {
            return storage.Create(diagnosisForAdd);
        }

        public List<Diagnosis> GetByPatient(Patient patient)
        {
            return storage.GetByPatient(patient);
        }
        public Diagnosis GetOne(int appointmentID)
        {
            return storage.GetOne(appointmentID);
        }
    }
}
