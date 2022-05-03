using System;

namespace SIMS.Model
{
    public class Allergy : Serialization.Serializable
    {
        public String Name { get; set; }

        public Allergy(String allergy)
        {
            this.Name = allergy;
        }

        public string[] toCSV()
        {
            string[] csvValues =
            {
                Name
            };
            return csvValues;
        }

        public void fromCSV(string[] values)
        {
            Name = values[0];
        }

        public Allergy() { }
    }
}
