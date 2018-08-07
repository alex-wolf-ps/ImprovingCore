using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Globomantics.Conventions
{
    public class BindName : Attribute, IParameterModelConvention
    {
        public string Name { get; set; }

        public void Apply(ParameterModel parameter)
        {
            if (parameter.BindingInfo == null)
            {
                parameter.BindingInfo = new BindingInfo();
            }

            parameter.BindingInfo.BinderModelName = Name;
        }
    }
}
