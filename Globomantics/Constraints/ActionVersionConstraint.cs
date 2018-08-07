using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Globomantics.Constraints
{
    public class ActionVersionConstraint : IActionConstraint
    {
        private double requiredVersion;

        public ActionVersionConstraint(double version)
        {
            this.requiredVersion = version;
        }

        public int Order { get; set; }

        public bool Accept(ActionConstraintContext context)
        {
            double parsedVersion = 0;

            if (double.TryParse(context.RouteContext.HttpContext.Request
                .Headers["x-version"].ToString(), out parsedVersion))
            {

                return parsedVersion >= requiredVersion &&
                    parsedVersion < requiredVersion + 1;
            }

            return false;
        }
    }
}
