using System;

namespace SIMS.Model
{
   public class City:Serialization.Serializable
   {
        private String _name;
      public String Name
        {
            get { return _name; } 
            set { if (value != _name) {
                    _name = value;
                } 
            }
        }

        public City(string name)
        {
            Name = name;
        }

        public City()
        {
        }

        public void fromCSV(string[] values)
        {
            Name = values[0];
        }

        public string[] toCSV()
        {
            String[] csvValues = { 
                Name
            };
            return csvValues;
        }

    }
}