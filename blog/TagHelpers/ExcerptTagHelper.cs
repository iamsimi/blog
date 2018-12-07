using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace blog.TagHelpers
{
    public class ExcerptTagHelper : TagHelper
    {
        public int summaryLength { get; set; }
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var content = await output.GetChildContentAsync();
            string target = content.GetContent();
            string summary = target.Substring(0, summaryLength);
            output.Content.SetHtmlContent(summary);
        }
    }
}
