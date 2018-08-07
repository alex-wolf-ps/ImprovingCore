using Globomantics.Core.Models;
using System.Collections.Generic;
using static Globomantics.Services.RateService;

namespace Globomantics.Services
{
    public interface IRateService
    {
        List<Rate> GetMortgageRates();

        List<Rate> GetCreditCardRates();

        List<CDRate> GetCDRates();

        double GetCDRateByTerm(CDTermLength term);
    }
}