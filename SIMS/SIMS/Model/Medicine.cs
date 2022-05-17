using System;
using System.Collections.Generic;


namespace SIMS.Model
{
    public class Medicine : Serialization.Serializable
    {
        public String Name { get; set; }
        public List<String> Ingredients { get; set; }
        public MedicineStatus MedicineStatus { get; set; }

        public int Quantity { get; set; }

        public Medicine(string name, List<string> ingredients, int quantity)
        {
            Name = name;
            Ingredients = ingredients;
            Quantity = quantity;
        }

        public Medicine(string name, List<string> ingredients, MedicineStatus medicineStatus, int quantity) : this(name, ingredients,quantity)
        {
            MedicineStatus = medicineStatus;
        }

        public string[] toCSV()
        {
            string[] csvValues = new string[Ingredients.Count +3];

            csvValues[0] = Name;
            csvValues[1] = MedicineStatus.ToString();
            csvValues[2] = Quantity.ToString();

            int i = 3;
            foreach (String s in Ingredients)
            {
                csvValues[i] = s;
                i++;
            }

            return csvValues;

        }

        public void fromCSV(string[] values)
        {
            if (values[0].Equals("")) 
            {
                return;
            }
            Name = values[0];
            MedicineStatus = (MedicineStatus)Enum.Parse(typeof(MedicineStatus), values[1]);
            Quantity = int.Parse(values[2]);

            Ingredients = new List<String>();
            for (int i = 3; i < values.Length; i++)
            {
                Ingredients.Add(values[i]);
            }
        }

        public Medicine() { }
    }
}