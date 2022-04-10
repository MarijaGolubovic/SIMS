using SIMS.Models;
using System;

namespace SIMS.Model
{
    public class MedicalRecord
    {
        public Double height;
        public Double weight;
        public String allergies;
        public BloodType bloodType;

        public System.Collections.Generic.List<Medicine> medicine;

        public System.Collections.Generic.List<Medicine> Medicine
        {
            get
            {
                if (medicine == null)
                    medicine = new System.Collections.Generic.List<Medicine>();
                return medicine;
            }
            set
            {
                RemoveAllMedicine();
                if (value != null)
                {
                    foreach (Medicine oMedicine in value)
                        AddMedicine(oMedicine);
                }
            }
        }


        public void AddMedicine(Medicine newMedicine)
        {
            if (newMedicine == null)
                return;
            if (this.medicine == null)
                this.medicine = new System.Collections.Generic.List<Medicine>();
            if (!this.medicine.Contains(newMedicine))
                this.medicine.Add(newMedicine);
        }


        public void RemoveMedicine(Medicine oldMedicine)
        {
            if (oldMedicine == null)
                return;
            if (this.medicine != null)
                if (this.medicine.Contains(oldMedicine))
                    this.medicine.Remove(oldMedicine);
        }


        public void RemoveAllMedicine()
        {
            if (medicine != null)
                medicine.Clear();
        }
        public Patient patient;

    }
}