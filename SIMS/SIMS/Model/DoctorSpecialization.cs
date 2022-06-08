using SIMS.Model;
using SIMS.Service;
using System;
using System.Collections.Generic;

namespace SIMS.Model
{
    public class DoctorSpecialization : Serialization.Serializable
    {
        public String JMBG { get; set; }

        public String Spec { get; set; }

        public DoctorSpecialization(string jMBG, string specialization)
        {
            JMBG = jMBG;
            Spec = specialization;
        }

        public DoctorSpecialization() { }
        public string[] toCSV()
        {
            string[] csvValues =
            {
                JMBG,
                Spec
            };
            return csvValues;
        }

        public void fromCSV(string[] values)
        {
            JMBG = values[0];
            Spec = values[1];
        }
    }
}
