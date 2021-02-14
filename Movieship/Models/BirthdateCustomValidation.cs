using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Movieship.ViewModel;

namespace Movieship.Models
{
    public class BirthdateCustomValidation:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if (customer.MembId == 0 || customer.MembId == 1)
                return ValidationResult.Success;
            if (customer.Birthdate == null)
                return new ValidationResult("Birthdate is required");//indicate error instanciate new validationResult

            var age = DateTime.Today.Year - customer.Birthdate.Value.Year;
            if (age >= 18)
                return ValidationResult.Success;
            else
                return new ValidationResult("Customer Should be 18 years old");
        }
    }
}