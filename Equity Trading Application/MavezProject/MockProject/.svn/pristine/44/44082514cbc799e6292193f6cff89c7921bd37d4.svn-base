using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Text.RegularExpressions;

namespace MasterDataManagementUI.Validations
{
    public class EntityMappingUIValidation : ValidationRule
    {
        public string RegexText { get; set; }
        public string ErrorMessage { get; set; }
        public RegexOptions regexOptions{ get; set; }

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            ValidationResult vResult = new ValidationResult(true, null);




            string iString = (value ?? string.Empty).ToString();

            //Regex regex = new Regex("[a-zA-Z]");
            if (!Regex.IsMatch(iString, "[a-zA-Z]"))
                vResult = new ValidationResult(false, ErrorMessage);
            return vResult;


            //ValidationResult result = ValidationResult.ValidResult;
            ////Regex regex = new Regex();
            //// If there is no regular expression to evaluate,
            //// then the data is considered to be valid.
            //if (!String.IsNullOrEmpty(this.RegexText))
            //{
            //    // Cast the input value to a string (null becomes empty string).
            //    string text = value as string ?? String.Empty;

            //    // If the string does not match the regex, return a value
            //    // which indicates failure and provide an error mesasge.
            //    if (!Regex.IsMatch(text, this.RegexText, this.regexOptions))
            //        result = new ValidationResult(false, this.ErrorMessage);
            //}

            //return result;

        }
    }
}
