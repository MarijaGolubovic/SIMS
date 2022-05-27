using System;
using SIMS.Model;
using SIMS.Repository;

namespace SIMS.Service
{
    public class DiagnosisService
    {
        public DiagnosisService() { }

        private readonly DiagnosisStorage storage = new DiagnosisStorage();

        public Boolean Create(Diagnosis diagnosisForAdd)
        {
            return storage.Create(diagnosisForAdd);
        }
    }
}
