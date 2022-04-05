using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Tasks.HtmlHelper
{
    public static class TasksHelper
    {
        public static HtmlString StateName(this IHtmlHelper html, string stateName) => 
            new HtmlString($@"<div><p class=""mt-3 mb-2 fw-bold border-bottom"">{stateName}</p></div>");
    }
}
