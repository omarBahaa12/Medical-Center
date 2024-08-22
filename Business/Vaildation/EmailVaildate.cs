using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataTier.Vaildation
{
    [AttributeUsage(AttributeTargets.Property,AllowMultiple =false) ]
    public class EmailVaildateAttribute:ValidationAttribute
    {
        readonly bool AllowsNull;
        public EmailVaildateAttribute(bool AllowsNull)
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

            if (!IsEmailValid(str))

                return new ValidationResult(Error.EmailNotMatch);

            return ValidationResult.Success;

        }

        protected bool IsEmailValid(string Email)
        {
            Regex regex = new Regex(@"^ [\w -\.] +@([\w -] +\.) + [\w -]{ 2,4}$", RegexOptions.IgnoreCase);

            return regex.IsMatch(Email);
        }
    }
}
