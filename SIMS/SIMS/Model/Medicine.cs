using System;
using System.Collections.Generic;


namespace SIMS.Model
{
    public class Medicine : Serialization.Serializable
    {
        public String Name { get; set; }
        public List<String> Ingredients { get; set; }
        public MedicineStatus MedicineStatus { get; set; }

        public Medicine(string name, List<string> ingredients)
        {
            Name = name;
            Ingredients = ingredients;
        }

        public Medicine(string name, List<string> ingredients, MedicineStatus medicineStatus) : this(name, ingredients)
        {
            MedicineStatus = medicineStatus;
        }

        public string[] toCSV()
        {
            string[] csvValues = new string[Ingredients.Count +2];

            csvValues[0] = Name;
            csvValues[1] = MedicineStatus.ToString();


            int i = 2;
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

            Ingredients = new List<String>();
            for (int i = 2; i < values.Length; i++)
            {
                Ingredients.Add(values[i]);
            }
        }

        public Medicine() { }
    }
}