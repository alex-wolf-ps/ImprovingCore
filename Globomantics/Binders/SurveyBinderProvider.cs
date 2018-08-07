using Globomantics.Core.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Globomantics.Binders
{
    public class SurveyBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context.Metadata.ModelType == typeof(List<Submission>))
            {
                return new SurveyBinder();
            }

            return null;
        }
    }
}
