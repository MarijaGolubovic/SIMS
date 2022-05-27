using System.Collections.Generic;
using SIMS.Model;
using SIMS.Repository;


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
