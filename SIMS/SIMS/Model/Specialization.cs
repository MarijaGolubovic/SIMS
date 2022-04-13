using System;

namespace SIMS.Model
{

    public class Specialization : Serialization.Serializable
    {
        public String Name { get; set; }

        public Specialization(string name)
        {
            Name = name;
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
    }
}