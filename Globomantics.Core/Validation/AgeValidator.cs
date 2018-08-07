using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Globomantics.Core.Validation
{
    public class AgeValidator : ValidationAttribute
    {
        public int Age { get; set; }

        public override bool IsValid(object value)
        {
            DateTime dob;
            if (value != null && DateTime.TryParse(value.ToString(), out dob))
            {
                if (dob.AddYears(Age) <= DateTime.Now)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
