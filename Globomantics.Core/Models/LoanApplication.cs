using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Globomantics.Models
{
    public class LoanApplication
    {
        public string LoanId { get; set; }
        public LoanDetails LoanInfo { get; set; }
        public Employment EmploymentInfo { get; set; }
        public Person PersonalInfo { get; set;}
        public bool LoanSubmitted { get; set; }
    }
}
