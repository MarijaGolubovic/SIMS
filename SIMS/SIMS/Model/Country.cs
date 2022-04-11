using System;

namespace SIMS.Model
{
   public class Country:Serialization.Serializable
   {
      public String Name { get; set; }

        public Country(string name)
        {
            Name = name;
        }

        public Country()
        {
        }

        public void fromCSV(string[] values)
        {
            Name = values[0];
        }

        public string[] toCSV()
        {
            String[] csvValues =
            {
                Name
            };
            return csvValues;
        }
    }
}