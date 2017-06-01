using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace vtoraya_laba
{
    public class NorEmtyValidationRules : ValidationRule
    {
        private const int MAX_VALUE = 25;
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            Int64 p = 0;
            if (p<0)
            {
                return new ValidationResult(false, "Товаров не может быть меньше нуля"); 
            }

            else
            {
                return new ValidationResult(true, String.Empty);
            }
        }
    }
}
