#pragma checksum "E:\work\POS-Lowcalories\POS\POS\Views\Holds\EditHold.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e207f04c0d3e238ca4dcb43a75637b51310b0a59"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Holds_EditHold), @"mvc.1.0.view", @"/Views/Holds/EditHold.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "E:\work\POS-Lowcalories\POS\POS\Views\_ViewImports.cshtml"
using POS;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\work\POS-Lowcalories\POS\POS\Views\_ViewImports.cshtml"
using POS.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\work\POS-Lowcalories\POS\POS\Views\_ViewImports.cshtml"
using POS.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "E:\work\POS-Lowcalories\POS\POS\Views\_ViewImports.cshtml"
using POS.ViewModel;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e207f04c0d3e238ca4dcb43a75637b51310b0a59", @"/Views/Holds/EditHold.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"39c148cdf359b210654bb7d9635177bfc3524c70", @"/Views/_ViewImports.cshtml")]
    public class Views_Holds_EditHold : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SerchVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("search"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "text", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control border-gradient d-inline-block w-50 radius py-4"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("placeholder", new global::Microsoft.AspNetCore.Html.HtmlString("customer number"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "SearchEditHold", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("search-btn w-100 text-center"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "DailyOrder", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "MakeTime", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn radius text-white bg-gradient approveOrder"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/layout/js/jquery-3.5.1.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"container my-4\">\r\n    <div class=\"row bg-white radius mx-2 py-3\">\r\n        <div class=\"col-lg-8 d-flex justify-content-center align-items-center\">\r\n            <!-- search input -->\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e207f04c0d3e238ca4dcb43a75637b51310b0a598142", async() => {
                WriteLiteral("\r\n                <button type=\"submit\" class=\"btn bg-gradient text-white radius m-2 search\" style=\"padding: 12px; vertical-align:0;\">search customer</button>\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "e207f04c0d3e238ca4dcb43a75637b51310b0a598582", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 8 "E:\work\POS-Lowcalories\POS\POS\Views\Holds\EditHold.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Custphone);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
        </div>
    </div>
</div>
<div class=""noti"">

</div>


<section id=""userTable2"">
    <div class=""container pb-5"">
        <table class=""table text-center"">
            <!-- table head -->
            <thead class=""text-white"">
                <tr>
                    <th>Order Number</th>
                    <th>Order Type</th>
                    <th>Customer Phone</th>
                    <th>Status</th>
                    <th>Cooking Time</th>
                    <th>Delivery Time</th>
                    <th>Details</th>
                    <th>Approval</th>
                </tr>
            </thead>
            <tbody id=""orders"" class=""text-muted"">
                <!-- first row -->
");
#nullable restore
#line 36 "E:\work\POS-Lowcalories\POS\POS\Views\Holds\EditHold.cshtml"
                 for (int i = 0; i < Model.Orders.Count(); i++)
                {
                    var d = Model.Orders[i].CookingTime;

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n\r\n                        <td data-label=\"Order Number\" class=\"pt-3\">");
#nullable restore
#line 41 "E:\work\POS-Lowcalories\POS\POS\Views\Holds\EditHold.cshtml"
                                                               Write(Model.Orders[i].Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td data-label=\"Order Type\" class=\"pt-3\">");
#nullable restore
#line 42 "E:\work\POS-Lowcalories\POS\POS\Views\Holds\EditHold.cshtml"
                                                             Write(Model.Orders[i].Type);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td data-label=\"Customer phone\">\r\n                            ");
#nullable restore
#line 44 "E:\work\POS-Lowcalories\POS\POS\Views\Holds\EditHold.cshtml"
                       Write(Model.Orders[i].CustPhone);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td data-label=\"Status\" class=\"pt-3\">\r\n");
#nullable restore
#line 47 "E:\work\POS-Lowcalories\POS\POS\Views\Holds\EditHold.cshtml"
                             if (Model.Orders[i].Status == 0)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <div>HOOLDING</div>\r\n");
#nullable restore
#line 50 "E:\work\POS-Lowcalories\POS\POS\Views\Holds\EditHold.cshtml"
                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 51 "E:\work\POS-Lowcalories\POS\POS\Views\Holds\EditHold.cshtml"
                             if (Model.Orders[i].Status == 1)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <div>PRAPERATION</div>\r\n");
#nullable restore
#line 54 "E:\work\POS-Lowcalories\POS\POS\Views\Holds\EditHold.cshtml"

                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </td>\r\n\r\n                        <!-- able to edit this data cell -->\r\n                        <td data-label=\"Cooking Time\" class=\"pt-3 editRow\">\r\n");
#nullable restore
#line 60 "E:\work\POS-Lowcalories\POS\POS\Views\Holds\EditHold.cshtml"
                             if (d.ToString() == "1/1/0001 12:00:00 AM")
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <div>----</div>\r\n");
#nullable restore
#line 63 "E:\work\POS-Lowcalories\POS\POS\Views\Holds\EditHold.cshtml"
                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 64 "E:\work\POS-Lowcalories\POS\POS\Views\Holds\EditHold.cshtml"
                             if (d.ToString() != "1/1/0001 12:00:00 AM")
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <div>");
#nullable restore
#line 66 "E:\work\POS-Lowcalories\POS\POS\Views\Holds\EditHold.cshtml"
                                Write(d);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
#nullable restore
#line 67 "E:\work\POS-Lowcalories\POS\POS\Views\Holds\EditHold.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </td>\r\n\r\n                        <!-- able to edit this data cell -->\r\n                        <td data-label=\"Delivery Time\" class=\"pt-3 editRow\">\r\n");
#nullable restore
#line 72 "E:\work\POS-Lowcalories\POS\POS\Views\Holds\EditHold.cshtml"
                             if (Model.Orders[i].DiliveryTime.ToString() == "1/1/0001 12:00:00 AM")
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <div>----</div>\r\n");
#nullable restore
#line 75 "E:\work\POS-Lowcalories\POS\POS\Views\Holds\EditHold.cshtml"
                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 76 "E:\work\POS-Lowcalories\POS\POS\Views\Holds\EditHold.cshtml"
                             if (Model.Orders[i].DiliveryTime.ToString() != "1/1/0001 12:00:00 AM")
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <div>");
#nullable restore
#line 78 "E:\work\POS-Lowcalories\POS\POS\Views\Holds\EditHold.cshtml"
                                Write(Model.Orders[i].DiliveryTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
#nullable restore
#line 79 "E:\work\POS-Lowcalories\POS\POS\Views\Holds\EditHold.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </td>\r\n                        <td data-label=\"Details\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e207f04c0d3e238ca4dcb43a75637b51310b0a5918236", async() => {
                WriteLiteral("<i class=\"fas fa-info-circle pointer\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 81 "E:\work\POS-Lowcalories\POS\POS\Views\Holds\EditHold.cshtml"
                                                                                                       WriteLiteral(Model.Orders[i].Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</td>\r\n\r\n                        <!-- Approve button  -->\r\n                        <td data-label=\"Approve\">\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e207f04c0d3e238ca4dcb43a75637b51310b0a5920829", async() => {
                WriteLiteral("Approve");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_9.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_9);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 85 "E:\work\POS-Lowcalories\POS\POS\Views\Holds\EditHold.cshtml"
                                                        WriteLiteral(Model.Orders[i].Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 88 "E:\work\POS-Lowcalories\POS\POS\Views\Holds\EditHold.cshtml"

                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n            </tbody>\r\n        </table>\r\n    </div>\r\n</section>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e207f04c0d3e238ca4dcb43a75637b51310b0a5923435", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_11);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
<script>
    //$(document).ready(function () {
    //    $("".search"").click(function () {
    //        var phone = $(""#search"").val();
    //        var url = ""/Holds/SearchEditHold"";
    //        //alert(phone);
    //        //$(""#orders"").empty();
    //        $.getJSON(url, { custnum: phone }, function (data) {

    //            console.log(data);
    //        });
    //    });
    //});
    //function getNotification() {
    //    $("".noti"").empty();
    //    $.ajax({
    //        url: ""/Holds/getNotification"",
    //        method: ""GET"",
    //        success: function (result) {
    //            $("".noti"").html(result);
    //            console.log(result);
    //        },
    //        error: function (error) {
    //            console.log(error);
    //        }
    //    });
    //}

    //getNotification();
    //let connection = new signalR.HubConnectionBuilder().withUrl(""/NotificationHub"").build();

    //connection.on(""NewOrder"", () => {
    //    ge");
            WriteLiteral("tNotification()\r\n    //})\r\n    //connection.start().catch(function (err) {\r\n    //    return console.error(err.toString());\r\n    //});\r\n</script>\r\n\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SerchVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
