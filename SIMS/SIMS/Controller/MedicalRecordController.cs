using SIMS.Model;
using SIMS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Controller
{
    public class MedicalRecordController
    {
        private readonly MedicalRecordService service;

        public MedicalRecordController() 
        {
            service = new MedicalRecordService();
        }

        public List<MedicalRecord> GetAll()
        {
            return service.GetAll();
        }

        public MedicalRecord GetOne(String jmbg)
        {
            return service.GetOne(jmbg);
        }
    }
}
