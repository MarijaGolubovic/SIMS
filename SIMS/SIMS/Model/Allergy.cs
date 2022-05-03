using System;

namespace SIMS.Model
{
    public class Allergy : Serialization.Serializable
    {
        public String allergy { get; set; }

        public Allergy(string allergy)
        {
            this.allergy = allergy;
        }

        public string[] toCSV()
        {
            string[] csvValues =
            {
                allergy
            };
            return csvValues;
        }

        public void fromCSV(string[] values)
        {
            allergy = values[0];
        }

        public Allergy() { }
    }
}
