using System.Collections.Generic;
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

        public List<Medicine> GetAllWithStatusOnHold()
        {
            return medicineService.GetAllWithStatusOnHold();
        }
        public bool Delete(Medicine medicine)
        {
            return medicineService.Delete(medicine);
        }

        public List<Medicine> GetAllWithStatusValid()
        {
            return medicineService.GetAllWithStatusValid();
        }
        public Medicine GetOne(string name)
        {
            return medicineService.GetOne(name);
        }

        public bool Create(Medicine medicine)
        {
            return medicineService.Create(medicine);
        }
        public void ChangeMedicineStatus(Medicine medicine)
        {

            medicineService.ChangeMedicineStatus(medicine);
        }
    }
}
