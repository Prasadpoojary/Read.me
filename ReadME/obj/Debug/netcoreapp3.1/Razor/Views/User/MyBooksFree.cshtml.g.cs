#pragma checksum "C:\Users\User\Desktop\Fri&Sis\SisProjects\Sent\senfsdf\ReadME\Views\User\MyBooksFree.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0de119d1ba3269bb57fd17ce96fc0f6128bd6814"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_MyBooksFree), @"mvc.1.0.view", @"/Views/User/MyBooksFree.cshtml")]
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
#nullable restore
#line 38 "C:\Users\User\Desktop\Fri&Sis\SisProjects\Sent\senfsdf\ReadME\Views\User\MyBooksFree.cshtml"
using ReadME.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0de119d1ba3269bb57fd17ce96fc0f6128bd6814", @"/Views/User/MyBooksFree.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"669956f466e7ffdd3292ae75daf33bf9bfbe94e4", @"/Views/_ViewImports.cshtml")]
    public class Views_User_MyBooksFree : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "Popular", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "Relevant", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "Language", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\User\Desktop\Fri&Sis\SisProjects\Sent\senfsdf\ReadME\Views\User\MyBooksFree.cshtml"
  
    Layout ="./../Shared/"+ViewBag.layoutName;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<section class=\"container\">\r\n\r\n    <div class=\"premium-container\">\r\n");
#nullable restore
#line 8 "C:\Users\User\Desktop\Fri&Sis\SisProjects\Sent\senfsdf\ReadME\Views\User\MyBooksFree.cshtml"
         if (ViewBag.books.Count > 0)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            <div class=""sub-header"">
                <div class=""sub-heading"">
                    <h2><span><i class=""fa fa-layer-group""></i></span> My Free Books</h2>
                </div>
                <div class=""sort-by-cat"">
                    <input type=""search""");
            BeginWriteAttribute("value", " value=\"", 454, "\"", 462, 0);
            EndWriteAttribute();
            WriteLiteral(" placeholder=\"Category\"");
            BeginWriteAttribute("name", " name=\"", 486, "\"", 493, 0);
            EndWriteAttribute();
            WriteLiteral(" list=\"searchDataCont\">\r\n\r\n                    <datalist id=\"searchDataCont\">\r\n");
#nullable restore
#line 18 "C:\Users\User\Desktop\Fri&Sis\SisProjects\Sent\senfsdf\ReadME\Views\User\MyBooksFree.cshtml"
                         foreach (string category in ViewBag.categories)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0de119d1ba3269bb57fd17ce96fc0f6128bd68146071", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 20 "C:\Users\User\Desktop\Fri&Sis\SisProjects\Sent\senfsdf\ReadME\Views\User\MyBooksFree.cshtml"
                               WriteLiteral(category);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 21 "C:\Users\User\Desktop\Fri&Sis\SisProjects\Sent\senfsdf\ReadME\Views\User\MyBooksFree.cshtml"

                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </datalist>\r\n                </div>\r\n                <div class=\"sort-by\">\r\n                    <input type=\"search\"");
            BeginWriteAttribute("value", " value=\"", 904, "\"", 912, 0);
            EndWriteAttribute();
            WriteLiteral(" placeholder=\"Sort by\"");
            BeginWriteAttribute("name", " name=\"", 935, "\"", 942, 0);
            EndWriteAttribute();
            WriteLiteral(" list=\"sortDataCont\">\r\n\r\n                    <datalist id=\"sortDataCont\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0de119d1ba3269bb57fd17ce96fc0f6128bd68148449", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0de119d1ba3269bb57fd17ce96fc0f6128bd68149591", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0de119d1ba3269bb57fd17ce96fc0f6128bd681410737", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </datalist>\r\n                </div>\r\n                <button><img class=\"send-icon\" src=\"./../../assets/Daco_4370644.png\" /></button>\r\n            </div>\r\n            <div class=\"book-container\">\r\n");
#nullable restore
#line 39 "C:\Users\User\Desktop\Fri&Sis\SisProjects\Sent\senfsdf\ReadME\Views\User\MyBooksFree.cshtml"
                 foreach (Book book in ViewBag.books)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <div class=""book-card"">
                        <div class=""more"">
                            <button><span><i class=""fa fa-ellipsis-v""></i></span></button>
                        </div>
                        <div class=""card-layer""></div>
                        <div class=""more-options"">
                            <ul>
");
#nullable restore
#line 48 "C:\Users\User\Desktop\Fri&Sis\SisProjects\Sent\senfsdf\ReadME\Views\User\MyBooksFree.cshtml"
                                 if (ViewBag.savedItems.Contains(book.Id))
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <a");
            BeginWriteAttribute("href", " href=\"", 2033, "\"", 2095, 3);
            WriteAttributeValue("", 2040, "/unsave/book/", 2040, 13, true);
#nullable restore
#line 50 "C:\Users\User\Desktop\Fri&Sis\SisProjects\Sent\senfsdf\ReadME\Views\User\MyBooksFree.cshtml"
WriteAttributeValue("", 2053, book.Id, 2053, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2061, "?redirect=?redirect=/myenrols/free", 2061, 34, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                        <li><span><i class=\"fa fa-bookmark\"></i></span> Unsave</li>\r\n                                    </a>\r\n");
#nullable restore
#line 53 "C:\Users\User\Desktop\Fri&Sis\SisProjects\Sent\senfsdf\ReadME\Views\User\MyBooksFree.cshtml"
                                }
                                else
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <a");
            BeginWriteAttribute("href", " href=\"", 2388, "\"", 2438, 3);
            WriteAttributeValue("", 2395, "/save/book/", 2395, 11, true);
#nullable restore
#line 56 "C:\Users\User\Desktop\Fri&Sis\SisProjects\Sent\senfsdf\ReadME\Views\User\MyBooksFree.cshtml"
WriteAttributeValue("", 2406, book.Id, 2406, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2414, "?redirect=/myenrols/free", 2414, 24, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                        <li><span><i class=\"fa fa-bookmark\"></i></span> Save</li>\r\n                                    </a>\r\n");
#nullable restore
#line 59 "C:\Users\User\Desktop\Fri&Sis\SisProjects\Sent\senfsdf\ReadME\Views\User\MyBooksFree.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                <li>\r\n                                    <button><span><i class=\"fa fa-share\"></i></span> Share</button>\r\n                                </li>\r\n\r\n                                <a");
            BeginWriteAttribute("href", " href=\"", 2834, "\"", 2881, 3);
            WriteAttributeValue("", 2841, "/report/", 2841, 8, true);
#nullable restore
#line 65 "C:\Users\User\Desktop\Fri&Sis\SisProjects\Sent\senfsdf\ReadME\Views\User\MyBooksFree.cshtml"
WriteAttributeValue("", 2849, book.Id, 2849, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2857, "?redirect=/myenrols/free", 2857, 24, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                    <li><span><i class=\"fa fa-ban\"></i></span> Report</li>\r\n                                </a>\r\n                                <a");
            BeginWriteAttribute("href", " href=\"", 3049, "\"", 3073, 2);
            WriteAttributeValue("", 3056, "/similar/", 3056, 9, true);
#nullable restore
#line 68 "C:\Users\User\Desktop\Fri&Sis\SisProjects\Sent\senfsdf\ReadME\Views\User\MyBooksFree.cshtml"
WriteAttributeValue("", 3065, book.Id, 3065, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
                                    <li><span><i class=""fa fa-th""></i></span> Similar</li>
                                </a>
                            </ul>
                        </div>
                        <div class=""book-heading"">
                            <h3>
                                ");
#nullable restore
#line 75 "C:\Users\User\Desktop\Fri&Sis\SisProjects\Sent\senfsdf\ReadME\Views\User\MyBooksFree.cshtml"
                           Write(book.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </h3>\r\n                            <div class=\"book-author\">\r\n                                - ");
#nullable restore
#line 78 "C:\Users\User\Desktop\Fri&Sis\SisProjects\Sent\senfsdf\ReadME\Views\User\MyBooksFree.cshtml"
                             Write(book.Author);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n                        <div class=\"book-thumbnail\">\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "0de119d1ba3269bb57fd17ce96fc0f6128bd681417556", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 3702, "~/", 3702, 2, true);
#nullable restore
#line 82 "C:\Users\User\Desktop\Fri&Sis\SisProjects\Sent\senfsdf\ReadME\Views\User\MyBooksFree.cshtml"
AddHtmlAttributeValue("", 3704, book.ThumbnailPath, 3704, 19, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 83 "C:\Users\User\Desktop\Fri&Sis\SisProjects\Sent\senfsdf\ReadME\Views\User\MyBooksFree.cshtml"
                             if (book.IsPremium)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <h4> Free<span></span></h4>\r\n");
#nullable restore
#line 86 "C:\Users\User\Desktop\Fri&Sis\SisProjects\Sent\senfsdf\ReadME\Views\User\MyBooksFree.cshtml"
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <h4>  Free<span></span></h4>\r\n");
#nullable restore
#line 90 "C:\Users\User\Desktop\Fri&Sis\SisProjects\Sent\senfsdf\ReadME\Views\User\MyBooksFree.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n                        <div class=\"book-checkout\">\r\n                            <a");
            BeginWriteAttribute("href", " href=\"", 4182, "\"", 4203, 2);
            WriteAttributeValue("", 4189, "/read/", 4189, 6, true);
#nullable restore
#line 94 "C:\Users\User\Desktop\Fri&Sis\SisProjects\Sent\senfsdf\ReadME\Views\User\MyBooksFree.cshtml"
WriteAttributeValue("", 4195, book.Id, 4195, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Read Now</a>\r\n                        </div>\r\n                        <div class=\"book-spec\">\r\n                            <div class=\"book-likes\">\r\n                                <p>");
#nullable restore
#line 98 "C:\Users\User\Desktop\Fri&Sis\SisProjects\Sent\senfsdf\ReadME\Views\User\MyBooksFree.cshtml"
                              Write(book.Likes);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n\r\n");
#nullable restore
#line 100 "C:\Users\User\Desktop\Fri&Sis\SisProjects\Sent\senfsdf\ReadME\Views\User\MyBooksFree.cshtml"
                                 if (ViewBag.likedItems.Contains(book.Id))
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <a");
            BeginWriteAttribute("href", " href=\"", 4557, "\"", 4602, 3);
            WriteAttributeValue("", 4564, "/like/", 4564, 6, true);
#nullable restore
#line 102 "C:\Users\User\Desktop\Fri&Sis\SisProjects\Sent\senfsdf\ReadME\Views\User\MyBooksFree.cshtml"
WriteAttributeValue("", 4570, book.Id, 4570, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4578, "?redirect=/myenrols/free", 4578, 24, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                        <i class=\"fa fa-heart\" style=\"color: #d41313;\"></i>\r\n                                    </a>\r\n");
#nullable restore
#line 105 "C:\Users\User\Desktop\Fri&Sis\SisProjects\Sent\senfsdf\ReadME\Views\User\MyBooksFree.cshtml"
                                }
                                else
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <a");
            BeginWriteAttribute("href", " href=\"", 4887, "\"", 4932, 3);
            WriteAttributeValue("", 4894, "/like/", 4894, 6, true);
#nullable restore
#line 108 "C:\Users\User\Desktop\Fri&Sis\SisProjects\Sent\senfsdf\ReadME\Views\User\MyBooksFree.cshtml"
WriteAttributeValue("", 4900, book.Id, 4900, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4908, "?redirect=/myenrols/free", 4908, 24, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                        <i class=\"fa fa-heart\"></i>\r\n                                    </a>\r\n");
#nullable restore
#line 111 "C:\Users\User\Desktop\Fri&Sis\SisProjects\Sent\senfsdf\ReadME\Views\User\MyBooksFree.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </div>\r\n                            <div class=\"book-views\">\r\n                                <p>");
#nullable restore
#line 114 "C:\Users\User\Desktop\Fri&Sis\SisProjects\Sent\senfsdf\ReadME\Views\User\MyBooksFree.cshtml"
                              Write(book.Readers);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                <a");
            BeginWriteAttribute("href", " href=\"", 5260, "\"", 5267, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                    <i class=\"fa fa-eye\"></i>\r\n                                </a>\r\n                            </div>\r\n                            <div class=\"book-feadback\">\r\n                                <p>");
#nullable restore
#line 120 "C:\Users\User\Desktop\Fri&Sis\SisProjects\Sent\senfsdf\ReadME\Views\User\MyBooksFree.cshtml"
                              Write(book.Comments);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                <a");
            BeginWriteAttribute("href", " href=\"", 5554, "\"", 5607, 3);
            WriteAttributeValue("", 5561, "/comment/book/", 5561, 14, true);
#nullable restore
#line 121 "C:\Users\User\Desktop\Fri&Sis\SisProjects\Sent\senfsdf\ReadME\Views\User\MyBooksFree.cshtml"
WriteAttributeValue("", 5575, book.Id, 5575, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5583, "?redirect=/myenrols/free", 5583, 24, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                    <i class=\"fa fa-comments\"></i>\r\n                                </a>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n");
#nullable restore
#line 127 "C:\Users\User\Desktop\Fri&Sis\SisProjects\Sent\senfsdf\ReadME\Views\User\MyBooksFree.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n");
#nullable restore
#line 129 "C:\Users\User\Desktop\Fri&Sis\SisProjects\Sent\senfsdf\ReadME\Views\User\MyBooksFree.cshtml"
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            <div class=""emptyCont"">
                <div class=""eiCross"">
                    <i class=""fa fa-times"" style=""color:#dfdfdf;font-size:42px;padding:15px 23px;border-radius: 50%;border:3px solid #dfdfdf;""></i>
                </div>
                <p class=""eiMain"">No Books Found</p>
                <p class=""eiSub"">Please Enroll the book. Enrolled Free books will be shown here.</p>
            </div>
");
#nullable restore
#line 139 "C:\Users\User\Desktop\Fri&Sis\SisProjects\Sent\senfsdf\ReadME\Views\User\MyBooksFree.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    </div>

    <div class=""most-valued-container"" style=""max-height: 300px;"">
        <div class=""my-items-cat"">
            <ul>
                <a href=""/myenrols/premium""><li class=""my-items-cat-one"">Premium Books</li></a>
                <a href=""/myenrols/free""><li class=""my-items-cat-two"">Free Books</li></a>
                <a href=""/myenrols/course""><li class=""my-items-cat-three"">Courses</li></a>
            </ul>
        </div>

    </div>
</section>");
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