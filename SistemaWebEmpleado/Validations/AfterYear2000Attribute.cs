using System;
using System.ComponentModel.DataAnnotations;

namespace SistemaWebEmpleado.Validations
{
    public class AfterYear2000Attribute : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            
            if (Convert.ToDateTime(value) < new DateTime(2000, 01, 01))
            {
                return new ValidationResult("La fecha de nacimiento solo puede ser posterior al 01/01/2000.");
            }

            return ValidationResult.Success;

        }

    }
}
