#pragma checksum "C:\Users\User\Desktop\Fri&Sis\SisProjects\Sent\senfsdf\ReadME\Views\User\Notification.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "88801e20e0b3e317af0a5fe21d9edfb08de55ca6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_Notification), @"mvc.1.0.view", @"/Views/User/Notification.cshtml")]
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
#line 14 "C:\Users\User\Desktop\Fri&Sis\SisProjects\Sent\senfsdf\ReadME\Views\User\Notification.cshtml"
using ReadME.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"88801e20e0b3e317af0a5fe21d9edfb08de55ca6", @"/Views/User/Notification.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"669956f466e7ffdd3292ae75daf33bf9bfbe94e4", @"/Views/_ViewImports.cshtml")]
    public class Views_User_Notification : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\User\Desktop\Fri&Sis\SisProjects\Sent\senfsdf\ReadME\Views\User\Notification.cshtml"
  
    Layout = "./../Shared/" + ViewBag.layoutName;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"


<section class=""container"">
    <div class=""premium-container"">
        <div class=""sub-header"">
            <div class=""sub-heading"">
                <h2><span><i class=""fa fa-bell""></i></span> Notifications</h2>
            </div>
        </div>
");
            WriteLiteral("; \r\n        <div class=\"All-notifications\">\r\n");
#nullable restore
#line 16 "C:\Users\User\Desktop\Fri&Sis\SisProjects\Sent\senfsdf\ReadME\Views\User\Notification.cshtml"
         foreach (Notification notification in ViewBag.Notifications)
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "C:\Users\User\Desktop\Fri&Sis\SisProjects\Sent\senfsdf\ReadME\Views\User\Notification.cshtml"
             if (ViewBag.newNotificationsId.Contains(notification.Id))
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"notification newnotify\">\r\n                <div class=\"newindicator\"></div>\r\n                <p>");
#nullable restore
#line 22 "C:\Users\User\Desktop\Fri&Sis\SisProjects\Sent\senfsdf\ReadME\Views\User\Notification.cshtml"
              Write(notification.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <span>");
#nullable restore
#line 23 "C:\Users\User\Desktop\Fri&Sis\SisProjects\Sent\senfsdf\ReadME\Views\User\Notification.cshtml"
                 Write(notification.TimeStamp);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n            </div>\r\n");
#nullable restore
#line 25 "C:\Users\User\Desktop\Fri&Sis\SisProjects\Sent\senfsdf\ReadME\Views\User\Notification.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 25 "C:\Users\User\Desktop\Fri&Sis\SisProjects\Sent\senfsdf\ReadME\Views\User\Notification.cshtml"
             

        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 29 "C:\Users\User\Desktop\Fri&Sis\SisProjects\Sent\senfsdf\ReadME\Views\User\Notification.cshtml"
         foreach (Notification notification in ViewBag.Notifications)
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 31 "C:\Users\User\Desktop\Fri&Sis\SisProjects\Sent\senfsdf\ReadME\Views\User\Notification.cshtml"
             if (!ViewBag.newNotificationsId.Contains(notification.Id))
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"notification\">\r\n                    <p>");
#nullable restore
#line 34 "C:\Users\User\Desktop\Fri&Sis\SisProjects\Sent\senfsdf\ReadME\Views\User\Notification.cshtml"
                  Write(notification.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    <span>");
#nullable restore
#line 35 "C:\Users\User\Desktop\Fri&Sis\SisProjects\Sent\senfsdf\ReadME\Views\User\Notification.cshtml"
                     Write(notification.TimeStamp);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                </div>\r\n");
#nullable restore
#line 37 "C:\Users\User\Desktop\Fri&Sis\SisProjects\Sent\senfsdf\ReadME\Views\User\Notification.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 37 "C:\Users\User\Desktop\Fri&Sis\SisProjects\Sent\senfsdf\ReadME\Views\User\Notification.cshtml"
             

        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n           \r\n        </div>\r\n    </div>\r\n</section>");
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