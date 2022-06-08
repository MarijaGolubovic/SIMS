using SIMS.Interfaces;
using SIMS.Model;
using SIMS.Repository;
using SIMS.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;


namespace SIMS.Service
{
    public class MedicalRecordService
    {
        private readonly IMedicalRecordStorage storage;

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
