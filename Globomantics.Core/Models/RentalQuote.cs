using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Globomantics.Models
{
    public class RentalQuote : Person
    {
        public string PropertyType { get; set; }
        public string MonthlyRent { get; set; }
        public string LeaseLength { get; set; }
        public int NumTenants{ get; set; }
    }
}
