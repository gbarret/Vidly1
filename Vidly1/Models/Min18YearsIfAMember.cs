using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;    // Use to derive class from  ValidationAttribute
using System.Linq;
using System.Web;

namespace Vidly1.Models
{
    public class Min18YearsIfAMember : ValidationAttribute

    {
        // This is Custom Validation ...
        // If MembershipType is "PayAsYouGo" then the customer has to be at least 18 years old ...
        // Here we need to override the "IsValid" Method (using 2 overload (object & context) in order to get access to other properties of the model)...
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // Custom Validation Logic. It requires to Cast itt using the model class (Customer) ...
            var customer = (Customer)validationContext.ObjectInstance;

            //if (customer.MembershipTypeId == 1)
            // 20190331 Refactoring magic Numbers (to make code more maintainable). Replacing 0 and 1 by defining the MembershipType 
            // 20190331 explicitly in the Domain Model (see MembershipType class) ...
            // if ( customer.MembershipTypeId == 0 || customer.MembershipTypeId == 1 )
            if (customer.MembershipTypeId == MembershipType.Unknown || 
                customer.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;

            if (customer.Birthdate == null)
                return new ValidationResult("Birthdate is required.");

            var age = DateTime.Today.Year - customer.Birthdate.Value.Year;

            return (age >= 18)
                ? ValidationResult.Success
                : new ValidationResult("Customer should be at least 18 years old to go on a membership.");
        }
    }
}