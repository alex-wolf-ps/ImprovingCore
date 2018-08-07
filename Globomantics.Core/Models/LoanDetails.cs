using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Globomantics.Models
{
    public class LoanDetails
    {
        [Required(ErrorMessage = "Loan Type is required")]
        public string Type { get; set; }

        [Required(ErrorMessage = "Amount is required")]
        public double? Amount { get; set; }

        [Required(ErrorMessage = "Term Length is required")]
        public int TermLength { get; set; }

        [Required(ErrorMessage = "Secured info is required")]
        public bool IsSecured { get; set; }
    }
}
