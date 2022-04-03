using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Tasks.HtmlHelper
{
    public static class TasksHelper
    {
        public static HtmlString StateName(this IHtmlHelper html, string stateName, string className) => 
            new HtmlString($@"<div><p class=""{className}"">{stateName}</p></div>");
    }
}
