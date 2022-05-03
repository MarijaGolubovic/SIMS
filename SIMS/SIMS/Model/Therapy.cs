using System;
using SIMS.Controller;

namespace SIMS.Model
{
    public class Therapy : Serialization.Serializable
    {
        public Medicine Medicine { get; set; }
        public String Period { get; set; }
        public String MethodOfTaking { get; set; }

        public string PatientId { get; set; }

        public Therapy(Medicine medicine, string period, string methodOfTaking, string id)
        {
            Medicine = medicine;
            Period = period;
            MethodOfTaking = methodOfTaking;
            PatientId = id;
        }

        public string[] toCSV()
        {
            string[] csvValues =
            {
                Medicine.Name,
                Period,
                MethodOfTaking,
                PatientId.ToString()
            };
            return csvValues;
        }

        public void fromCSV(string[] values)
        {
            MedicineContoller mc = new MedicineContoller();
            if (values[0] == "")
                return;
            Medicine = mc.GetOne(values[0]);
            Period = values[1];
            MethodOfTaking = values[2];
            PatientId = values[3];
        }

        public Therapy() { }
    }
}
