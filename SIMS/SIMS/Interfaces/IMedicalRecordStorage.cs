using SIMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
