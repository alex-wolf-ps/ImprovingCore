using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Globomantics.Models
{
    public class LoanDetails
    {
        [Required]
        public string Type { get; set; }

        [Required]
        public double? Amount { get; set; }

        [Required]
        public int TermLength { get; set; }

        [Required]
        public bool IsSecured { get; set; }
    }
}
