using SIMS.Model;
using SIMS.Service;
using System;
using System.Collections.Generic;

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
