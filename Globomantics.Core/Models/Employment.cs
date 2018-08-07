using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Globomantics.Models
{
    public class Employment : IValidatableObject
    {
        [Required(ErrorMessage = "Current employment type required")]
        public string CurrentType { get; set; }
        [Required(ErrorMessage = "Current employer required")]
        public string CurrentEmployerName { get; set; }
        [Required(ErrorMessage = "Current annual income required")]
        public double? CurrentAnnualIncome { get; set; }
        [Required(ErrorMessage = "Current employment duration required")]
        public double? CurrentDuration { get; set; }

        public string PreviousType { get; set; }
        public string PreviousEmployerName { get; set; }
        public double? PreviousAnnualIncome { get; set; }
        public double? PreviousDuration { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            if (CurrentDuration < 2)
            {
                if (string.IsNullOrEmpty(PreviousType)
                    || string.IsNullOrEmpty(PreviousEmployerName)
                    || PreviousDuration == null)
                {
                    errors.Add(new ValidationResult("Previous Employment Information Required"));
                }
            }

            return errors;
        }
    }
}
