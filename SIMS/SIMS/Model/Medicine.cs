using System;
using System.Collections.Generic;


namespace SIMS.Model
{
    public class Medicine : Serialization.Serializable
    {
        public String Name { get; set; }

        public List<String> Ingredients { get; set; }

        private int numOdIndgredients;
        public Medicine(string name, List<string> ingredients)
        {
            Name = name;
            Ingredients = ingredients;
        }

        public string[] toCSV()
        {
            string[] csvValues = { Name };

            int i = 1;
            foreach (String s in Ingredients)
            {
                csvValues[i] = s;
                i++;
            }

            return csvValues;

        }

        public void fromCSV(string[] values)
        {
            Name = values[0];

            for (int i = 1; i < values.Length; i++)
            {
                Ingredients.Add(values[i]);
            }
        }

        public Medicine() { }
    }
}