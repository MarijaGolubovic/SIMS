using System.Collections.Generic;
using SIMS.Model;
using SIMS.Repository;
using System.Collections.Generic;


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

        public List<Medicine> GetAllWithStatusOnHold() 
        {
            List<Medicine> medicines = new List<Medicine>();
            foreach(Medicine med in GetAll())
            {
                if(med.MedicineStatus.Equals(MedicineStatus.OnHold))
                    medicines.Add(med);
            }
            return medicines;
        }

        public List<Medicine> GetAllWithStatusValid()
        {
            List<Medicine> medicines = new List<Medicine>();
            foreach (Medicine med in GetAll())
            {
                if (med.MedicineStatus.Equals(MedicineStatus.Valid))
                    medicines.Add(med);
            }
            return medicines;
        }

        public Medicine GetOne(string name)
        {
            return medicineStorage.GetOne(name);
        }

        public bool Create(Medicine medicine)
        {
            return medicineStorage.Create(medicine);
        }
        public bool Delete(Medicine medicine)
        {
            return medicineStorage.Delete(medicine);
        }

        public void ChangeMedicineStatus(Medicine medicine)
        {

            medicineStorage.ChangeMedicineStatus(medicine);
        }
    }
}
