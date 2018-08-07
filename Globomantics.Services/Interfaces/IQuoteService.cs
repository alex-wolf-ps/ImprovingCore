using Globomantics.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Globomantics.Services
{
    public interface IQuoteService
    {
        void GenerateAutoQuote(AutoQuote quote);
        void GeneratePropertyQuote(PropertyQuote quote);
        void GenerateLifeQuote(LifeQuote quote);
        void GenerateRentalQuote(RentalQuote quote);
    }
}
