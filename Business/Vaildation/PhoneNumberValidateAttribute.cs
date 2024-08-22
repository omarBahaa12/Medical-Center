using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataTier.Vaildation
{
    [AttributeUsage(AttributeTargets.Property,AllowMultiple =false)]
    public class PhoneNumberValidateAttribute:ValidationAttribute
    {
        readonly bool AllowsNull;
        public PhoneNumberValidateAttribute(bool AllowsNull)
        {
            this.AllowsNull = AllowsNull;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string? str = value as string;

            if (AllowsNull && string.IsNullOrWhiteSpace(str))

                return ValidationResult.Success;

            if (string.IsNullOrWhiteSpace(str))

                return new ValidationResult(Error.Required);

            if (!IsPhoneValid(str))

                return new ValidationResult(Error.PhoneNumberNotMatch);

            return ValidationResult.Success;

        }

        protected bool IsPhoneValid(string Phone)
        {
            Regex regex = new Regex("^[0-9]{11}", RegexOptions.IgnoreCase);

            return regex.IsMatch(Phone);
        }
    }
}
