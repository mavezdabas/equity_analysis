using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace EquityTradingApplication.Helpers
{
    public class UserNameValidator:ValidationRule
    {
      //  public int MaxLength { get; set; }
       // public int MinLength { get; set; }
      //  public string ErrorMessage { get; set; }

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (string.IsNullOrEmpty(value.ToString()))
                return new ValidationResult(false,"Username cannot be left empty!");
            //else if (value.ToString().Length < 3)
            //{

            //    return new ValidationResult(false, "Username should have atleast 3 characters!");
            //}

            //else
            //{
            //    if (value.ToString().Length > 12)
            //        return new ValidationResult(false, "Username cannot exceed 12 characters!");

            //}
            return ValidationResult.ValidResult;
        }
    }
}
