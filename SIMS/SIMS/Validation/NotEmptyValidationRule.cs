using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SIMS.Validation
{
    public class NotEmptyValidationRule : ValidationRule
    {

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string charStr = value as string;
            if (string.IsNullOrWhiteSpace(charStr))
            {
                return new ValidationResult(false, $"Ovo polje je obavezno popuniti!");
            }
            else
            {
                return new ValidationResult(true, null);
            }
        }
    }
}
