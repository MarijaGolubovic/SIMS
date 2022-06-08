using SIMS.Model;
using SIMS.Service;
using System;
using System.Collections.Generic;



namespace SIMS.Controller
{
    public class MedicineContoller
    {
        private readonly MedicineService medicineService;

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

        public bool IsThereMedicineForValidation()
        {
            if (medicineService.GetAllWithStatusOnHold().Count == 0)
                return false;
            else
                return true;
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
        public void ChangeMedicineStatusOnValid(Medicine medicine)
        {

            medicineService.ChangeMedicineStatusOnValid(medicine);
        }
        public void ChangeMedicineStatusOnInvalid(Medicine medicine)
        {
            medicineService.ChangeMedicineStatusOnInvalid(medicine);
        }


        public void EditMedicine(Medicine oldMedicine, Medicine newMedicine)
        {

            medicineService.EditMedicine(oldMedicine, newMedicine);
        }
    }
}
