using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Globomantics.Models
{
    public class AutoQuote : Person
    {
        public string Make { get; set; }
        public string Year { get; set; }
        public string Price { get; set; }
        public string Type { get; set; }
    }
}
