using System;
using System.Collections.Generic;
using SIMS.Model;

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

        public void Update(String jmbg, MedicalRecord medicalRecord)
        {
            storage.Update(jmbg, medicalRecord);
        }
    }
}
