using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CustomValidator
{
    /// <summary>
    /// This Class is used to validate Maximum Event Date.
    /// </summary>
    class MaxEventDateValidator:ValidationAttribute
    {
        protected override ValidationResult
                IsValid(object value, ValidationContext validationContext)
        {
            DateTime _eventDate = Convert.ToDateTime(value);
            if (_eventDate < DateTime.Now.AddYears(1))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult
                    ("Event date should be with in one year.");
            }
        }
    }
}
