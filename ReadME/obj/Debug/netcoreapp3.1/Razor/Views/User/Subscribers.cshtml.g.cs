#pragma checksum "C:\Users\User\Desktop\Fri&Sis\SisProjects\Sent\senfsdf\ReadME\Views\User\Subscribers.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d27ea1659b6096ff43847728617ca9ea4d9d04fe"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_Subscribers), @"mvc.1.0.view", @"/Views/User/Subscribers.cshtml")]
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
#line 8 "C:\Users\User\Desktop\Fri&Sis\SisProjects\Sent\senfsdf\ReadME\Views\User\Subscribers.cshtml"
using ReadME.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d27ea1659b6096ff43847728617ca9ea4d9d04fe", @"/Views/User/Subscribers.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"669956f466e7ffdd3292ae75daf33bf9bfbe94e4", @"/Views/_ViewImports.cshtml")]
    public class Views_User_Subscribers : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\User\Desktop\Fri&Sis\SisProjects\Sent\senfsdf\ReadME\Views\User\Subscribers.cshtml"
  
    Layout = "./../Shared/" + ViewBag.layoutName;



#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("\r\n<section class=\"container\">\r\n    <div class=\"premium-container\">\r\n\r\n");
#nullable restore
#line 13 "C:\Users\User\Desktop\Fri&Sis\SisProjects\Sent\senfsdf\ReadME\Views\User\Subscribers.cshtml"
         if (ViewBag.subscribers.Count > 0)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <h2>Subscribers</h2>\r\n            <div class=\"subscribers\">\r\n");
#nullable restore
#line 17 "C:\Users\User\Desktop\Fri&Sis\SisProjects\Sent\senfsdf\ReadME\Views\User\Subscribers.cshtml"
                 foreach (User user in ViewBag.subscribers)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <a");
            BeginWriteAttribute("href", " href=\"", 390, "\"", 424, 3);
            WriteAttributeValue("", 397, "/portfolio/", 397, 11, true);
#nullable restore
#line 19 "C:\Users\User\Desktop\Fri&Sis\SisProjects\Sent\senfsdf\ReadME\Views\User\Subscribers.cshtml"
WriteAttributeValue("", 408, user.Id, 408, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 416, "/premium", 416, 8, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                        <div class=\"subscriber\">\r\n\r\n                            <div class=\"subscriber-name\">\r\n                                <h5>");
#nullable restore
#line 23 "C:\Users\User\Desktop\Fri&Sis\SisProjects\Sent\senfsdf\ReadME\Views\User\Subscribers.cshtml"
                               Write(user.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                            </div>\r\n                            <div class=\"subscriber-email\">\r\n                                <p>");
#nullable restore
#line 26 "C:\Users\User\Desktop\Fri&Sis\SisProjects\Sent\senfsdf\ReadME\Views\User\Subscribers.cshtml"
                              Write(user.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            </div>\r\n\r\n                        </div>\r\n                    </a>\r\n");
#nullable restore
#line 31 "C:\Users\User\Desktop\Fri&Sis\SisProjects\Sent\senfsdf\ReadME\Views\User\Subscribers.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n");
#nullable restore
#line 33 "C:\Users\User\Desktop\Fri&Sis\SisProjects\Sent\senfsdf\ReadME\Views\User\Subscribers.cshtml"
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
                <p class=""eiMain"">No Subscribers Found</p>
                <p class=""eiSub"">When somebody subscribed to you then you can see them here.</p>
            </div>
");
#nullable restore
#line 43 "C:\Users\User\Desktop\Fri&Sis\SisProjects\Sent\senfsdf\ReadME\Views\User\Subscribers.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</section>");
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