using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Globomantics.Services
{
    public class FeatureService : IFeatureService
    {
        private Dictionary<string, bool> featureStates = new Dictionary<string, bool>()
        {
            { "Quotes", true },
            { "Loans", true },
            { "Resources", true },
            { "BusinessServices", true}
        };

        public bool IsFeatureActive(string featureName)
        {
            return featureStates.FirstOrDefault(x => x.Key == featureName).Value;
        }
    }
}
