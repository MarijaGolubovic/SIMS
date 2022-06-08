using SIMS.Controller;
using SIMS.Model;
using SIMS.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
namespace SIMS.Model
{
    public class Therapy : Serialization.Serializable
    {
        public Medicine Medicine { get; set; }
        public String PeriodInHours { get; set; }
        public String MethodOfTaking { get; set; }
        public String PeriodInDays { get; set; }

        public DateTime timeOfMaking { get; set; }
        public string PatientId { get; set; }

        public Therapy(Medicine medicine, string periodInHours, string methodOfTaking, string periodInDays, DateTime timeOfMaking, string patientId)
        {
            Medicine = medicine;
            PeriodInHours = periodInHours;
            MethodOfTaking = methodOfTaking;
            PeriodInDays = periodInDays;
            this.timeOfMaking = timeOfMaking;
            PatientId = patientId;
        }

        public string[] toCSV()
        {
            string[] csvValues =
            {
                Medicine.Name,
                PeriodInHours,
                PeriodInDays,
                MethodOfTaking,
                PatientId.ToString(),
                timeOfMaking.ToString(),
            };
            return csvValues;
        }

        public void fromCSV(string[] values)
        {
            MedicineContoller mc = new MedicineContoller();
            if (values[0] == "")
                return;
            Medicine = mc.GetOne(values[0]);
            PeriodInHours = values[1];
            PeriodInDays = values[2];
            MethodOfTaking = values[3];
            PatientId = values[4];
            timeOfMaking = DateTime.Parse(values[5]);
        }

        public Therapy() { }
    }
}
