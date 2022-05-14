using SIMS.Model;
using SIMS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
