using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Text.RegularExpressions;

namespace MasterDataManagementUI
{
    public class StringLengthValidationRule : ValidationRule
    {
        public int MinimumLength { get; set; }
        public int MaximumLength { get; set; }
        public string ErrorMessage { get; set; }

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            ValidationResult vResult = new ValidationResult(true, null);
            string iString = (value ?? string.Empty).ToString();
            bool b = IsAlphabets(iString);
            if (iString.Length < this.MinimumLength ||
                (this.MaximumLength > 0 && iString.Length > this.MaximumLength))
                b = false;

            if(b==false)
                vResult = new ValidationResult(false, ErrorMessage);
            return vResult;
        }
        public bool IsAlphabets(string inputString)
        {
            if (string.IsNullOrEmpty(inputString))
                return false;

            //for (int i = 0; i < inputString.Length; i++)
            if (!(char.IsLetter(inputString[0]) || (char.IsDigit(inputString[0]))))
                    return false;
            if (!(char.IsLetter(inputString[(inputString.Length-1)]) || (char.IsDigit(inputString[(inputString.Length-1)]))))
                return false;
            return true;
        }
    }
}
