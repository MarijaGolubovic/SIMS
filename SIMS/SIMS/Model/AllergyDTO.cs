using SIMS.Model;
using SIMS.Service;
using System;
using System.Collections.Generic;

namespace SIMS.Model
{
    public class AllergyDTO
    {
        public String AllergyName { get; set; }
        public Boolean IsSelected { get; set; }

        public AllergyDTO(string allergyName, bool isSelected)
        {
            AllergyName = allergyName;
            IsSelected = isSelected;
        }
    }
}
