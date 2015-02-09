using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Text.RegularExpressions;

namespace EquityTradingApp.Helpers
{
   public class PasswordValidator:ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (string.IsNullOrEmpty(value.ToString()))
                return new ValidationResult(false, "Password cannot be left empty!");
            else if (!Regex.IsMatch(value.ToString(), "[a-zA-z]"))
            {
                return new ValidationResult(false, "Password should contain atleast one upper or lower case alphabet!");
            }

            else if (!Regex.IsMatch(value.ToString(), "[0-9]"))
            {
                return new ValidationResult(false, "Password should contain atleast 1 numeric character!");
            }

            else if (value.ToString().Length < 6)
            {
                return new ValidationResult(false, "Password should have atleast 6 charcters!");
            }

            else 
            { 
                if (value.ToString().Length > 12)
                    return new ValidationResult(false, "Password should not have more than 12 charcters!");
            }

            return ValidationResult.ValidResult;
        }
    }
}
