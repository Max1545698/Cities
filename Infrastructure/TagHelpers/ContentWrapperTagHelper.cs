﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Cities.Infrastructure.TagHelpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("div", Attributes = "title")]
    public class ContentWrapperTagHelper : TagHelper
    {
        public bool IncludeHeader { get; set; } = true;
        public bool IncludeFooter { get; set; } = true;
        public string Title { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.SetAttribute("class", "m-1 p-1");

            TagBuilder title = new TagBuilder("h1");
            title.InnerHtml.Append(Title);

            TagBuilder container = new TagBuilder("div");
            container.Attributes["class"] = "bg-info m-1 p-1";

            container.InnerHtml.AppendHtml(title);

            if (IncludeHeader)
            {
                output.PreElement.SetHtmlContent(container);
            }

            if (IncludeFooter)
            {
                output.PostElement.SetHtmlContent(container);
            }
        }
    }
}
