using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Globomantics.Models
{
    public class PropertyQuote : Person
    {
        public string PropertyType { get; set; }
        public string HomeValue { get; set; }
        public string YearBuilt { get; set; }
        public string NumResidents { get; set; }
        public string AreaCode { get; set; }
    }
}
