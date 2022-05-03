using SIMS.Model;
using SIMS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
