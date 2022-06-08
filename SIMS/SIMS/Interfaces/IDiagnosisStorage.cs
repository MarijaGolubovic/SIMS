using SIMS.Interfaces;
using SIMS.Model;
using System;
using System.Collections.Generic;

namespace SIMS.Interfaces
{
    internal interface IDiagnosisStorage
    {
        public List<Diagnosis> GetAll();
        public Diagnosis GetOne(int appointmentID);
        public List<Diagnosis> GetByPatient(Patient patient);
        public Boolean Delete(int appointmentID);
        public Boolean Create(Diagnosis diagnosisForAdd);
        public Boolean Update(Appointment appointment);
    }
}
