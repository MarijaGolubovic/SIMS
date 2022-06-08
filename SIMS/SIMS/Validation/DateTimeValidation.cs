using System;
using System.Globalization;
using System.Windows.Controls;

namespace SIMS.Validation
{
    class DateTimeValidation : ValidationRule
    {

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            DateTime time;
            return DateTime.TryParse((value ?? "").ToString(),
                CultureInfo.CurrentCulture,
                DateTimeStyles.AssumeLocal | DateTimeStyles.AllowWhiteSpaces,
                out time)
                ? ValidationResult.ValidResult
                : new ValidationResult(false, "Unesite ispravan datum!");
        }
    }
}
