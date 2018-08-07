using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Globomantics.Models
{
    public class Employment
    {
        public string CurrentType { get; set; }
        public string CurrentEmployerName { get; set; }
        public double? CurrentAnnualIncome { get; set; }
        public string CurrentDuration { get; set; }

        public string PreviousType { get; set; }
        public string PreviousEmployerName { get; set; }
        public double? PreviousAnnualIncome { get; set; }
        public string PreviousDuration { get; set; }
    }
}
