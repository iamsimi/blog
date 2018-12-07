using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blog.TagHelpers
{
    public class DateInWordsTagHelper : TagHelper
    {
        Dictionary<int, string> months =
            new Dictionary<int, string>() { { 01, "JAN"}, { 02, "FEB" }, { 03, "MAR" },{ 04, "APR"},
                { 05, "MAY"},{ 06, "JUN"}, { 07, "JUL"}, { 08, "AUG"}, { 09, "SEPT"},{ 10, "OCT"}, { 11, "NOV"},{ 12, "DEC"},};
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "p";
            var content = await output.GetChildContentAsync();
            string datePublished = content.GetContent();
            string[] sdata;
            char[] delimiter = new char[] { '/' };
            sdata = datePublished.Split(delimiter);

            string outputDate = sdata[1] +" "+ months[int.Parse(sdata[0])] +" "+ sdata[2];
            output.Content.SetContent(outputDate);
        }
    }
}
