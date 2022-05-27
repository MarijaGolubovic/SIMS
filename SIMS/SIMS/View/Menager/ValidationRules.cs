using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SIMS.View.Menager
{
    class ValidationRules : ValidationRule
    {
        public ValidationRules()
        {
        }

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            try
            {
                var s = value as string;
                double r;
                if (double.TryParse(s, out r))
                {
                    return new ValidationResult(true, null);
                }
                return new ValidationResult(false, "Please enter a valid double value.");
            }
            catch
            {
                return new ValidationResult(false, "Unknown error occured.");
            }
        }
    }


    class ValidationEmptyFileds : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            try
            {
                
                if (value==null)
                {
                    return new ValidationResult(true, null);
                }
                return new ValidationResult(false, "Please enter a valid value");
            }
            catch
            {
                return new ValidationResult(false, "Unknown error occured.");
            }
        }
    }

}
