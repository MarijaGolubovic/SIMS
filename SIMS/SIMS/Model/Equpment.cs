using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Model
{
    class Equpment: Serialization.Serializable
    {
        public String Name { get; set; }
        public int Quantity{ get; set; }

        public Equpment(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }

        public Equpment()
        {
        }

        public string[] toCSV()
        {
            string[] csvValues = {
                Name,
                Quantity.ToString()

            };
            return csvValues;
        }

        public void fromCSV(string[] values)
        {
            Name = values[0];
            Quantity = int.Parse(values[1]);
        }

        String _Name;
        int _Quantity;

        public static explicit operator Equpment(string v)
        {
            throw new NotImplementedException();
        }
    }
}
