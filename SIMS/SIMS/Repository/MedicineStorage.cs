using System;
using System.Collections.Generic;
using SIMS.Model;

namespace SIMS.Repository
{
    public class MedicineStorage
    {
        public List<Medicine> GetAll()
        {
            Serialization.Serializer<Medicine> medicineSerializer = new Serialization.Serializer<Medicine>();
            List<Medicine> medicines = medicineSerializer.fromCSV("medicine.txt");

            return medicines;
        }

        public Medicine GetOne(string name)
        {
            List<Medicine> medicines = GetAll();
            Medicine medicine = new Medicine();

            foreach (Medicine m in medicines)
            {
                if (m.Name.Equals(name))
                {
                    medicine = m;
                    break;
                }
            }
            return medicine;

        }

        public Boolean Delete(int name)
        {
            throw new NotImplementedException();
        }
        public static Boolean Create(Medicine medicine)
        {
            throw new NotImplementedException();
        }

        public Boolean Update(Medicine medicine)
        {
            throw new NotImplementedException();
        }

        public String fileName;
    }
}
