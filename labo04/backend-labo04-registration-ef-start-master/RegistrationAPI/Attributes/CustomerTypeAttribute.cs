using System;
using System.ComponentModel.DataAnnotations;
using RegistrationAPI.Models;

namespace RegistrationAPI.Attributes
{
    public class CustomerTypeAttribute : ValidationAttribute
    {
        public CustomerTypeAttribute()
        {

        }
/*
        public string GetErrorMessage() => $"Invalid customer type";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if ((customer.CustomerType == "Privé") ||  (customer.CustomerType == "Business"))
            {
                return ValidationResult.Success;
            }
            return  new ValidationResult("Invalid customer type");
        }
*/
    }


}
