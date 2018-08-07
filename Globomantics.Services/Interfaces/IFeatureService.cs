using System;
using System.Collections.Generic;
using System.Text;

namespace Globomantics.Services
{
    public interface IFeatureService
    {
        bool IsFeatureActive(string featureName);
    }
}
