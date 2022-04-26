using SIMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
