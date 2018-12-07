using HeyRed.MarkdownSharp;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blog.TagHelpers
{
    public class MarkdownTagHelper : TagHelper
    {
        public string Source { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Attributes.SetAttribute("class", "markdown-contents");
            var markdown = new Markdown();
            output.Content.SetHtmlContent(markdown.Transform(this.Source));
        }
    }
}
