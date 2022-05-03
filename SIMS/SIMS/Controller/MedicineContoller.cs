using SIMS.Model;
using SIMS.Service;
using System.Collections.Generic;

namespace SIMS.Controller
{
    public class MedicineContoller
    {
        private MedicineService medicineService;

        public MedicineContoller()
        {
            medicineService = new MedicineService();
        }

        public List<Medicine> GetAll()
        {
            return medicineService.GetAll();
        }

        public Medicine GetOne(string name)
        {
            return medicineService.GetOne(name);
        }
    }
}
