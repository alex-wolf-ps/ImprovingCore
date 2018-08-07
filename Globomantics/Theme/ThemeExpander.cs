using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Globomantics.Theme
{
    public class ThemeExpander : IViewLocationExpander
    {
        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            var activeTheme = context.Values["ACTIVE_THEME"];
            var expandedLocations = viewLocations.ToList();

            for (int i = 0; i < viewLocations.Count(); i++)
            {
                expandedLocations.Insert(i, viewLocations.ElementAt(i)
                    .Replace("/Views/", string.Format("/Views/Themes/{0}/", activeTheme)));
            }

            return expandedLocations;
        }

        public void PopulateValues(ViewLocationExpanderContext context)
        {
            var appSettings = (IConfiguration)context.ActionContext.HttpContext
                                .RequestServices.GetService(typeof(IConfiguration));

            context.Values["ACTIVE_THEME"] = appSettings["AppSettings:ActiveTheme"];
        }
    }
}
