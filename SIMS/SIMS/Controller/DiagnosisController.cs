using System;
using SIMS.Model;
using SIMS.Service;

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
    }
}
