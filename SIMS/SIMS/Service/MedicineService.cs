using SIMS.Model;
using SIMS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Service
{
    public class MedicineService
    {
        private MedicineStorage medicineStorage { get; set; }

        public MedicineService() 
        {
            medicineStorage = new MedicineStorage();
        }

        public List<Medicine> GetAll() 
        {
            return medicineStorage.GetAll();
        }

        public Medicine GetOne(string name)
        {
            return medicineStorage.GetOne(name);
        }
    }
}
