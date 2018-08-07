using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Globomantics.Filters
{
    public class RateExceptionFilter : ExceptionFilterAttribute, IResourceFilter
    {
        public override void OnException(ExceptionContext context)
        {
            if(context.Exception is TimeoutException)
            {
                context.Result = new StatusCodeResult(504);
            }
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            throw new NotImplementedException();
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            throw new NotImplementedException();
        }
    }
}
