using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXCBookStore.COMMON.Validations
{
    public class CustomPasswordValidationAttribute : ValidationAttribute
    {
        private readonly string otherProperty;

        public CustomPasswordValidationAttribute(string otherProperty)
        {
            this.otherProperty = otherProperty;
            ErrorMessage = "The password and confirmation password do not match.";
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var propertyInfo = validationContext.ObjectType.GetProperty(otherProperty);

            if (propertyInfo == null)
            {
                throw new ArgumentException("Property with this name not found");
            }

            var otherValue = propertyInfo.GetValue(validationContext.ObjectInstance, null);

            if (value == null || otherValue == null || !value.Equals(otherValue))
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
