using Globomantics.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Globomantics.Services
{
    public class RateService : IRateService
    {
        public List<Rate> GetMortgageRates()
        {
            return new List<Rate>()
            {
                new Rate { Title = "10 Year", Value = 3.5, Type = RateType.Mortgage },
                new Rate { Title = "15 Year", Value = 4.0, Type = RateType.Mortgage },
                new Rate { Title = "30 Year", Value = 4.5, Type = RateType.Mortgage }
            };
        }

        public List<Rate> GetCreditCardRates()
        {
            return new List<Rate>
            {
                new Rate { Title = "Platinum", Value = 6, Type = RateType.CreditCard },
                new Rate { Title = "Premium Platinum", Value = 7, Type = RateType.CreditCard },
                new Rate { Title = "Platinum Unlimited", Value = 8, Type = RateType.CreditCard }
            };
        }

        public List<CDRate> GetCDRates()
        {
            return new List<CDRate>
            {
                new CDRate() { TermLength = CDTermLength.Months12, Title = "12 Months", Value = 1, Type = RateType.CD },
                new CDRate() { TermLength = CDTermLength.Months18, Title = "18 Months", Value = 1.5, Type = RateType.CD },
                new CDRate() { TermLength = CDTermLength.Months24, Title = "24 Months", Value = 2, Type = RateType.CD },
                new CDRate() { TermLength = CDTermLength.Months36, Title = "36 Months", Value = 2.5, Type = RateType.CD }
            };
        }

        public double GetCDRateByTerm(CDTermLength term)
        {
            return GetCDRates().FirstOrDefault(x => x.TermLength == term).Value;
        }

    }
}
