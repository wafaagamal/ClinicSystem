#pragma checksum "C:\Users\wafaa\source\repos\ClincERD\MVC_Clinic\Views\Doctor\GetDoctor.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3a245490609cd9626f1cd14c48118e4209e1c34f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Doctor_GetDoctor), @"mvc.1.0.view", @"/Views/Doctor/GetDoctor.cshtml")]
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
#line 1 "C:\Users\wafaa\source\repos\ClincERD\MVC_Clinic\Views\_ViewImports.cshtml"
using MVC_Clinic;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\wafaa\source\repos\ClincERD\MVC_Clinic\Views\_ViewImports.cshtml"
using MVC_Clinic.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3a245490609cd9626f1cd14c48118e4209e1c34f", @"/Views/Doctor/GetDoctor.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ed78ccd0fa98c81a8511d79c2cb06bc815fd0964", @"/Views/_ViewImports.cshtml")]
    public class Views_Doctor_GetDoctor : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Business.Presentation.DoctorVM>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\wafaa\source\repos\ClincERD\MVC_Clinic\Views\Doctor\GetDoctor.cshtml"
  
    ViewData["Title"] = "GetDoctor";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Doctor Details</h1>\r\n\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 15 "C:\Users\wafaa\source\repos\ClincERD\MVC_Clinic\Views\Doctor\GetDoctor.cshtml"
           Write(Html.DisplayNameFor(model => model.UserName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 18 "C:\Users\wafaa\source\repos\ClincERD\MVC_Clinic\Views\Doctor\GetDoctor.cshtml"
           Write(Html.DisplayNameFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 21 "C:\Users\wafaa\source\repos\ClincERD\MVC_Clinic\Views\Doctor\GetDoctor.cshtml"
           Write(Html.DisplayNameFor(model => model.IsActive));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 24 "C:\Users\wafaa\source\repos\ClincERD\MVC_Clinic\Views\Doctor\GetDoctor.cshtml"
           Write(Html.DisplayNameFor(model => model.MobileNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n\r\n        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 33 "C:\Users\wafaa\source\repos\ClincERD\MVC_Clinic\Views\Doctor\GetDoctor.cshtml"
           Write(Html.DisplayFor(modelItem => Model.UserName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 36 "C:\Users\wafaa\source\repos\ClincERD\MVC_Clinic\Views\Doctor\GetDoctor.cshtml"
           Write(Html.DisplayFor(modelItem => Model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 39 "C:\Users\wafaa\source\repos\ClincERD\MVC_Clinic\Views\Doctor\GetDoctor.cshtml"
           Write(Html.DisplayFor(modelItem => Model.IsActive));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 42 "C:\Users\wafaa\source\repos\ClincERD\MVC_Clinic\Views\Doctor\GetDoctor.cshtml"
           Write(Html.DisplayFor(modelItem => Model.MobileNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 45 "C:\Users\wafaa\source\repos\ClincERD\MVC_Clinic\Views\Doctor\GetDoctor.cshtml"
           Write(Html.ActionLink("MyAppointments", "MyAppointments","Doctor" ,new { id = Model.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n            </td>\r\n        </tr>\r\n    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Business.Presentation.DoctorVM> Html { get; private set; }
    }
}
#pragma warning restore 1591