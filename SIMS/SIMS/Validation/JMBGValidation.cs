using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;
namespace SIMS.Validation
{
    public class JMBGValidation : ValidationRule
    {
        private static readonly Regex _regexForEmail = new Regex(@"^([0-9]{13})$");
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string charString = value as string;

            //Slucaj da su uneti RAZMACI
            if (String.IsNullOrEmpty(charString) || String.IsNullOrWhiteSpace(charString))
            {
                return new ValidationResult(false, $"Ovo polje ne sme biti prazno!");
            }
            else if (charString.StartsWith(" "))
            {
                return new ValidationResult(false, $"Neispravan unos. Ovo polje ne sme sadrzati razmak!");
            }

            else if (!_regexForEmail.IsMatch(charString))
            {
                if (charString.Contains(" "))
                {
                    return new ValidationResult(false, $"Neispravan unos. Ovo polje ne sme sadrzati razmak!");
                }

                return new ValidationResult(false, $"Neispravan unos. JMBG mora imati 13 cifra!");
            }


            return new ValidationResult(true, null);
        }
    }
}
