#pragma checksum "C:\Users\User\Desktop\Fri&Sis\SisProjects\Sent\senfsdf\ReadME\Views\User\CommentCourse.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "aa954d74d74780d0a83c9d3c8bb2fde88a8dffe2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_CommentCourse), @"mvc.1.0.view", @"/Views/User/CommentCourse.cshtml")]
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
#line 1 "C:\Users\User\Desktop\Fri&Sis\SisProjects\Sent\senfsdf\ReadME\Views\_ViewImports.cshtml"
using ReadME;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"aa954d74d74780d0a83c9d3c8bb2fde88a8dffe2", @"/Views/User/CommentCourse.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"669956f466e7ffdd3292ae75daf33bf9bfbe94e4", @"/Views/_ViewImports.cshtml")]
    public class Views_User_CommentCourse : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("user-ticket-form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\User\Desktop\Fri&Sis\SisProjects\Sent\senfsdf\ReadME\Views\User\CommentCourse.cshtml"
  
    Layout = "./../Shared/" + ViewBag.layoutName;

#line default
#line hidden
#nullable disable
            WriteLiteral("<section class=\"container\">\r\n\r\n    <div class=\"most-valued-container\">\r\n\r\n        <div class=\"book-container\">\r\n            <div class=\"book-card\">\r\n\r\n                <div class=\"book-heading\">\r\n                    <h3>\r\n                        ");
#nullable restore
#line 13 "C:\Users\User\Desktop\Fri&Sis\SisProjects\Sent\senfsdf\ReadME\Views\User\CommentCourse.cshtml"
                   Write(ViewBag.course.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </h3>\r\n                    <div class=\"book-author\">\r\n                        - ");
#nullable restore
#line 16 "C:\Users\User\Desktop\Fri&Sis\SisProjects\Sent\senfsdf\ReadME\Views\User\CommentCourse.cshtml"
                     Write(ViewBag.course.Source);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n                <div class=\"book-thumbnail\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "aa954d74d74780d0a83c9d3c8bb2fde88a8dffe25471", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 577, "~/", 577, 2, true);
#nullable restore
#line 20 "C:\Users\User\Desktop\Fri&Sis\SisProjects\Sent\senfsdf\ReadME\Views\User\CommentCourse.cshtml"
AddHtmlAttributeValue("", 579, ViewBag.course.ThumbnailPath, 579, 29, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    <h4>  Free<span></span></h4>\r\n                </div>\r\n                <div class=\"book-checkout\">\r\n                    <a");
            BeginWriteAttribute("href", " href=\"", 760, "\"", 790, 2);
            WriteAttributeValue("", 767, "view/", 767, 5, true);
#nullable restore
#line 24 "C:\Users\User\Desktop\Fri&Sis\SisProjects\Sent\senfsdf\ReadME\Views\User\CommentCourse.cshtml"
WriteAttributeValue("", 772, ViewBag.course.Id, 772, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">View Now</a>\r\n                </div>\r\n                <div class=\"book-spec\">\r\n                    <div class=\"book-likes\">\r\n                        <p>");
#nullable restore
#line 28 "C:\Users\User\Desktop\Fri&Sis\SisProjects\Sent\senfsdf\ReadME\Views\User\CommentCourse.cshtml"
                      Write(ViewBag.course.Likes);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n\r\n");
#nullable restore
#line 30 "C:\Users\User\Desktop\Fri&Sis\SisProjects\Sent\senfsdf\ReadME\Views\User\CommentCourse.cshtml"
                         if (ViewBag.isLiked)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <a");
            BeginWriteAttribute("href", " href=\"", 1077, "\"", 1152, 4);
            WriteAttributeValue("", 1084, "/like/", 1084, 6, true);
#nullable restore
#line 32 "C:\Users\User\Desktop\Fri&Sis\SisProjects\Sent\senfsdf\ReadME\Views\User\CommentCourse.cshtml"
WriteAttributeValue("", 1090, ViewBag.course.Id, 1090, 18, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1108, "?redirect=/comment/course/", 1108, 26, true);
#nullable restore
#line 32 "C:\Users\User\Desktop\Fri&Sis\SisProjects\Sent\senfsdf\ReadME\Views\User\CommentCourse.cshtml"
WriteAttributeValue("", 1134, ViewBag.course.Id, 1134, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                <i class=\"fa fa-heart\" style=\"color: #d41313;\"></i>\r\n                            </a>\r\n");
#nullable restore
#line 35 "C:\Users\User\Desktop\Fri&Sis\SisProjects\Sent\senfsdf\ReadME\Views\User\CommentCourse.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <a");
            BeginWriteAttribute("href", " href=\"", 1389, "\"", 1464, 4);
            WriteAttributeValue("", 1396, "/like/", 1396, 6, true);
#nullable restore
#line 38 "C:\Users\User\Desktop\Fri&Sis\SisProjects\Sent\senfsdf\ReadME\Views\User\CommentCourse.cshtml"
WriteAttributeValue("", 1402, ViewBag.course.Id, 1402, 18, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1420, "?redirect=/comment/course/", 1420, 26, true);
#nullable restore
#line 38 "C:\Users\User\Desktop\Fri&Sis\SisProjects\Sent\senfsdf\ReadME\Views\User\CommentCourse.cshtml"
WriteAttributeValue("", 1446, ViewBag.course.Id, 1446, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                <i class=\"fa fa-heart\"></i>\r\n                            </a>\r\n");
#nullable restore
#line 41 "C:\Users\User\Desktop\Fri&Sis\SisProjects\Sent\senfsdf\ReadME\Views\User\CommentCourse.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </div>\r\n                    <div class=\"book-views\">\r\n                        <p>");
#nullable restore
#line 44 "C:\Users\User\Desktop\Fri&Sis\SisProjects\Sent\senfsdf\ReadME\Views\User\CommentCourse.cshtml"
                      Write(ViewBag.course.Readers);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                        <a");
            BeginWriteAttribute("href", " href=\"", 1746, "\"", 1753, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                            <i class=\"fa fa-eye\"></i>\r\n                        </a>\r\n                    </div>\r\n                    <div class=\"book-feadback\">\r\n                        <p>");
#nullable restore
#line 50 "C:\Users\User\Desktop\Fri&Sis\SisProjects\Sent\senfsdf\ReadME\Views\User\CommentCourse.cshtml"
                      Write(ViewBag.course.Comments);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                        <a");
            BeginWriteAttribute("href", " href=\"", 2002, "\"", 2087, 4);
            WriteAttributeValue("", 2009, "/comment/course/", 2009, 16, true);
#nullable restore
#line 51 "C:\Users\User\Desktop\Fri&Sis\SisProjects\Sent\senfsdf\ReadME\Views\User\CommentCourse.cshtml"
WriteAttributeValue("", 2025, ViewBag.course.Id, 2025, 18, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2043, "?redirect=checkout/course/", 2043, 26, true);
#nullable restore
#line 51 "C:\Users\User\Desktop\Fri&Sis\SisProjects\Sent\senfsdf\ReadME\Views\User\CommentCourse.cshtml"
WriteAttributeValue("", 2069, ViewBag.course.Id, 2069, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
                            <i class=""fa fa-comments""></i>
                        </a>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class=""premium-container"">
        <h2>Write something about this Course</h2>
        <div class=""ticket-form"">
            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "aa954d74d74780d0a83c9d3c8bb2fde88a8dffe212929", async() => {
                WriteLiteral("\r\n                <div class=\"textarea-holder\">\r\n                    <textarea placeholder=\"Let us know your opinion...\" name=\"commenttext\"");
                BeginWriteAttribute("id", " id=\"", 2669, "\"", 2674, 0);
                EndWriteAttribute();
                WriteLiteral(" cols=\"30\" rows=\"10\"></textarea>\r\n                    <p class=\"textarea-count\">\r\n                        <span class=\"textarea-len\">0</span> of 500\r\n                    </p>\r\n                </div>\r\n                <button>Send</button>\r\n            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "action", 4, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 2431, "/comment/course/", 2431, 16, true);
#nullable restore
#line 62 "C:\Users\User\Desktop\Fri&Sis\SisProjects\Sent\senfsdf\ReadME\Views\User\CommentCourse.cshtml"
AddHtmlAttributeValue("", 2447, ViewBag.course.Id, 2447, 18, false);

#line default
#line hidden
#nullable disable
            AddHtmlAttributeValue("", 2465, "?redirect=", 2465, 10, true);
#nullable restore
#line 62 "C:\Users\User\Desktop\Fri&Sis\SisProjects\Sent\senfsdf\ReadME\Views\User\CommentCourse.cshtml"
AddHtmlAttributeValue("", 2475, ViewBag.redirect, 2475, 17, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</section> ");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
