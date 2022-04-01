using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Text;
using System.Text.Encodings.Web;
using Tasks.Models;

namespace Tasks.HtmlHelper
{
    public static class TasksHelper
    {
        public static HtmlContentBuilder CreateTaskList(this IHtmlHelper html, IEnumerable<TaskModel> items, Dictionary<int, string> states)
        {
            var div = new HtmlContentBuilder();
            var block1 = new HtmlContentBuilder().AppendHtml("<div>");
            var block2 = new HtmlContentBuilder().AppendHtml("<div>");
            var block3 = new HtmlContentBuilder().AppendHtml("<div>");
            foreach (var item in items)
            {
               string str = $@"<div class=""row co-sm-8 w-100 m-0"" id=""sortable""><div class=""col-sm-3 pt-3"">
                                      <div class=""card"">
                                          <span class=""p-2"">{states[item.StateId]}</span>
                                                <div class=""btn-group w-50 position-absolute top-0 end-0"" role=""group"" aria-label=""Basic mixed styles example"">
                                                <a asp-controller=""Home"" asp-action=""Delete"" asp-route-id=""@{item.Id}"" class=""btn btn-outline-light"">
                                                    <svg xmlns = ""http://www.w3.org/2000/svg"" width=""16"" height=""16"" color=""#ff000078"" fill=""currentColor"" class=""bi bi-trash3"" viewBox=""0 0 16 16"">
                                                        <path d = ""M6.5 1h3a.5.5 0 0 1 .5.5v1H6v-1a.5.5 0 0 1 .5-.5ZM11 2.5v-1A1.5 1.5 0 0 0 9.5 0h-3A1.5 1.5 0 0 0 5 1.5v1H2.506a.58.58 0 0 0-.01 0H1.5a.5.5 0 0 0 0 1h.538l.853 10.66A2 2 0 0 0 4.885 16h6.23a2 2 0 0 0 1.994-1.84l.853-10.66h.538a.5.5 0 0 0 0-1h-.995a.59.59 0 0 0-.01 0H11Zm1.958 1-.846 10.58a1 1 0 0 1-.997.92h-6.23a1 1 0 0 1-.997-.92L3.042 3.5h9.916Zm-7.487 1a.5.5 0 0 1 .528.47l.5 8.5a.5.5 0 0 1-.998.06L5 5.03a.5.5 0 0 1 .47-.53Zm5.058 0a.5.5 0 0 1 .47.53l-.5 8.5a.5.5 0 1 1-.998-.06l.5-8.5a.5.5 0 0 1 .528-.47ZM8 4.5a.5.5 0 0 1 .5.5v8.5a.5.5 0 0 1-1 0V5a.5.5 0 0 1 .5-.5Z"" />
                                                    </svg>
                                                </a>
                                                <button type=""button"" onclick=""setValueMW({item.Id})"" class=""btn btn-outline-light"" data-bs-toggle=""modal"" data-bs-target=""#ModalTask"">
                                                    <svg xmlns = ""http://www.w3.org/2000/svg"" width=""16"" height=""16"" color=""#000000a6"" fill=""currentColor"" class=""bi bi-pencil"" viewBox=""0 0 16 16"">
                                                        <path d = ""M12.146.146a.5.5 0 0 1 .708 0l3 3a.5.5 0 0 1 0 .708l-10 10a.5.5 0 0 1-.168.11l-5 2a.5.5 0 0 1-.65-.65l2-5a.5.5 0 0 1 .11-.168l10-10zM11.207 2.5 13.5 4.793 14.793 3.5 12.5 1.207 11.207 2.5zm1.586 3L10.5 3.207 4 9.707V10h.5a.5.5 0 0 1 .5.5v.5h.5a.5.5 0 0 1 .5.5v.5h.293l6.5-6.5zm-9.761 5.175-.106.106-1.528 3.821 3.821-1.528.106-.106A.5.5 0 0 1 5 12.5V12h-.5a.5.5 0 0 1-.5-.5V11h-.5a.5.5 0 0 1-.468-.325z"" ></ path >
                                                    </ svg>
                                                </button>
                                            </div>
                                            <div class=""card-body cut-text"">
                                                <h5 id = ""t-{item.Id}"" class=""card-title mTitlet-3"">{item.Title}</h5>
                                                <p id = ""d-{item.Id}"" class=""card-text"">{item.Describe}</p>
                                            </div>
                                        </div>
                                    </div></div>";

                switch (item.StateId)
                {
                    case 1:
                        block1.AppendHtml(str);
                        break;
                    case 2:
                        block2.AppendHtml(str);
                        break;
                    case 3:
                        block3.AppendHtml(str);
                        break;
                }
            }

            block1.AppendHtml("</div>");
            block2.AppendHtml("</div>");
            block3.AppendHtml("</div>");

            div.AppendHtml(block1);
            div.AppendHtml(block2);
            div.AppendHtml(block3);

             var writer = new System.IO.StringWriter();
            div.WriteTo(writer, HtmlEncoder.Default);

            return div;
        }
    }
}
