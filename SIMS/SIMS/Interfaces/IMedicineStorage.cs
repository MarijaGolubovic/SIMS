using SIMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Interfaces
{
    internal interface IMedicineStorage
    {
        public List<Medicine> GetAll();
        public Medicine GetOne(string name);
        public Boolean Delete(Medicine medicine);
        public Boolean Create(Medicine medicine);
        public void ChangeMedicineStatusOnValid(Medicine medicine);
        public void ChangeMedicineStatusOnInvalid(Medicine medicine);
        public void EditMedicine(Medicine oldMedicine, Medicine newMedicine);
    }
}
