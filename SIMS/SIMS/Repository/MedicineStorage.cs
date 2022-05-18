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

        public Boolean Delete(Medicine medicine)
        {
            List<Medicine> medicines = GetAll();
            medicines.Remove(medicine);
            Serialization.Serializer<Medicine> medicineSerializer = new Serialization.Serializer<Medicine>();
            medicineSerializer.toCSV("medicine.txt", medicines);
            return true;
        }
        public Boolean Create(Medicine medicine)
        {
            List<Medicine> medicines = GetAll();
            medicines.Add(medicine);
            Serialization.Serializer<Medicine> medicineSerializer = new Serialization.Serializer<Medicine>();
            medicineSerializer.toCSV("medicine.txt", medicines);
            return true;
        }

        public Boolean Update(Medicine medicine)
        {
            throw new NotImplementedException();
        }

        public void ChangeMedicineStatusOnValid(Medicine medicine)
        {
            List<Medicine> medicines = GetAll();
            foreach (Medicine med in medicines)
            {
                if (med.Name.Equals(medicine.Name))
                {
                    med.MedicineStatus = MedicineStatus.Valid;
                    break;
                }
            }

            Serialization.Serializer<Medicine> medicineSerializer = new Serialization.Serializer<Medicine>();
            medicineSerializer.toCSV("medicine.txt", medicines);

        }

        public void ChangeMedicineStatusOnInvalid(Medicine medicine)
        {
            List<Medicine> medicines = GetAll();
            foreach (Medicine med in medicines)
            {
                if (med.Name.Equals(medicine.Name))
                {
                    med.MedicineStatus = MedicineStatus.Invalid;
                }
            }

            Serialization.Serializer<Medicine> medicineSerializer = new Serialization.Serializer<Medicine>();
            medicineSerializer.toCSV("medicine.txt", medicines);

        }

        public String fileName;

        public void EditMedicine(Medicine oldMedicine, Medicine newMedicine)
        {
            Delete(oldMedicine);
            Create(newMedicine);
        }
    }
}
