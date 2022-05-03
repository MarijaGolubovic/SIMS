using SIMS.Model;
using System;
using System.Collections.Generic;

namespace SIMS.Service
{
    public class MedicalRecordService
    {
        private readonly MedicalRecordStorage storage;

        public MedicalRecordService()
        {
            storage = new MedicalRecordStorage();
        }

        public List<MedicalRecord> GetAll()
        {
            return storage.GetAll();
        }

        public MedicalRecord GetOne(String jmbg)
        {
            return storage.GetOne(jmbg);
        }
    }
}
