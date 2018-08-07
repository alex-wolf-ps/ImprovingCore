using System;
using System.Collections.Generic;
using System.Text;

namespace Globomantics.Core.Models
{
    public class Rate
    {
        public string Title { get; set; }
        public double Value { get; set; }
        public RateType Type { get; set; }
    }

    public enum RateType
    {
        Mortgage,
        CreditCard,
        CD
    }
}
