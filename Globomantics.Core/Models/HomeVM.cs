using System;
using System.Collections.Generic;
using System.Text;

namespace Globomantics.Core.Models
{
    public class HomeVM
    {
        public List<Rate> MortgageRates { get; set; }
        public List<Rate> CreditCardRates { get; set; }
        public List<CDRate> CDRates { get; set; }
    }
}
