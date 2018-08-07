using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Globomantics.Models
{
    public class AutoQuote : Person
    {
        public string Make { get; set; }
        public double Year { get; set; }
        public double Price { get; set; }
        public string Type { get; set; }
    }
}
