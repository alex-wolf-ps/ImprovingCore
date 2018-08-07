using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Globomantics.TagHelpers
{
    [HtmlTargetElement("banner")]
    public class BannerTagHelper : TagHelper
    {
        public string Title { get; set; }

        public string SubTitle { get; set; }

        public string BackgroundColor { get; set; }

        public override void Process(TagHelperContext context, 
            TagHelperOutput output)
        {
            output.Content.SetHtmlContent(
                $@"<div class=""jumbotron jumbotron-fluid jumbotron-{BackgroundColor}"">
                    <div class=""container"">
                        <h1 class=""display-4"">{ Title }</h1>
                        <p class=""lead"">{ SubTitle }</p>
                    </div>
                </div>");
        }
    }
}
