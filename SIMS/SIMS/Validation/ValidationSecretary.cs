using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;
namespace SIMS.Validation
{
    public class StringToDoubleValidationRule : ValidationRule
    {
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


    public class EmailRule : ValidationRule
    {

        private static readonly Regex _regexForEmail = new Regex(@"^([^\s]+@[a-z]+\.com)$");


        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string charString = value as string;

            //Slucaj da su uneti RAZMACI
            if (String.IsNullOrEmpty(charString) || String.IsNullOrWhiteSpace(charString))
            {
                return new ValidationResult(false, $"Ovo polje ne sme biti prazno. Potrebno je uneti Email u formatu \"gmail@gmail.com\"!");
            }
            else if (charString.StartsWith(" "))
            {
                return new ValidationResult(false, $"Neispravan unos. Ovo polje ne sme sadrzati razmak!");
            }

            //Email NE ZADOVOLJAVA FORMAT
            else if (!_regexForEmail.IsMatch(charString))
            {
                if (charString.Contains(" "))
                {
                    return new ValidationResult(false, $"Neispravan unos. Ovo polje ne sme sadrzati razmak!");
                }

                return new ValidationResult(false, $"Neispravan unos. Email mora biti u formatu \"gmail@gmail.com\"!");
            }


            return new ValidationResult(true, null);
        }

    }
}
