using Microsoft.AspNetCore.Mvc.ActionConstraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Globomantics.Constraints
{
    public class MobileSelector : Attribute, IActionConstraint
    {
        public int Order { get; set; }

        public bool Accept(ActionConstraintContext context)
        {
            return context.RouteContext.HttpContext.Request
                .Headers["user-agent"].ToString().Contains("Android");
        }
    }
}
