using System;
using System.Collections.Generic;


namespace SIMS.Model
{
   public class Medicine
   {
      public String Name { get; set; }

        public List<String> Ingredients { get; set; }
        public Medicine(string name, List<string> ingredients)
        {
            Name = name;
            Ingredients = ingredients;
        }
    }
}