using SIMS.Interfaces;
using SIMS.Model;
using System;
using System.Collections.Generic;

namespace SIMS.Interfaces
{
    internal interface IMedicalRecordStorage
    {
        public List<MedicalRecord> GetAll();
        public MedicalRecord GetOne(String jmbg);
        public Boolean Create(MedicalRecord medicalRecord);
        public Boolean Update(String jmbg, MedicalRecord medicalRecord);
    }
}
