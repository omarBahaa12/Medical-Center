

using System.ComponentModel.DataAnnotations;

namespace DataTier.Vaildation
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class StringValidationAttribute : ValidationAttribute
    {
        readonly bool AllowsNull;

        readonly int Min;

        readonly int Max;
        public StringValidationAttribute(bool AllowsNull, int Max, int Min = -1)
        {
            this.AllowsNull = AllowsNull;

            this.Min = Min;

            this.Max = Max;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string? str = value as string;

            if (AllowsNull && string.IsNullOrWhiteSpace(str))

                return ValidationResult.Success;

            if (string.IsNullOrWhiteSpace(str))

                return new ValidationResult(Error.Required);

            if (str.Length < Min && Min!= -1)

                return new ValidationResult(Error.LessthanLimit(Min));

            if (str.Length > Max)

                return new ValidationResult(Error.OutofLimit(Max));

            return ValidationResult.Success;

        }
    }
}
