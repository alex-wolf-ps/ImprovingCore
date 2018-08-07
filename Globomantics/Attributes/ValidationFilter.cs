using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Globomantics.Attributes
{
    public class ValidationFilter : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var controller = context.Controller as Controller;
            var viewData = controller.ViewData;

            if (!viewData.ModelState.IsValid)
            {
                context.Result = new ViewResult
                {
                    ViewData = viewData,
                    TempData = controller.TempData
                };
            }
        }
    }
}
