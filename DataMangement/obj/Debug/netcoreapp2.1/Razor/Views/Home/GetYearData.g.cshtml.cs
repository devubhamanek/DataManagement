#pragma checksum "D:\Mahavir Backup\Projects\DataManagement\Source\DataMangement\Views\Home\GetYearData.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "be303e56c9881fca06a16eadcf71784f70756926"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_GetYearData), @"mvc.1.0.view", @"/Views/Home/GetYearData.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/GetYearData.cshtml", typeof(AspNetCore.Views_Home_GetYearData))]
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
#line 1 "D:\Mahavir Backup\Projects\DataManagement\Source\DataMangement\Views\_ViewImports.cshtml"
using DataMangement;

#line default
#line hidden
#line 2 "D:\Mahavir Backup\Projects\DataManagement\Source\DataMangement\Views\_ViewImports.cshtml"
using DataMangement.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"be303e56c9881fca06a16eadcf71784f70756926", @"/Views/Home/GetYearData.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"11c19027dae96b3018eb40aaa421f92aa78d3222", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_GetYearData : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Dm.Common.Models.YearTree>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(47, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "D:\Mahavir Backup\Projects\DataManagement\Source\DataMangement\Views\Home\GetYearData.cshtml"
  
    ViewData["Title"] = "GetYearData";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(143, 110, true);
            WriteLiteral("\r\n<h2>GetYearData</h2>\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(254, 40, false);
#line 14 "D:\Mahavir Backup\Projects\DataManagement\Source\DataMangement\Views\Home\GetYearData.cshtml"
           Write(Html.DisplayNameFor(model => model.year));

#line default
#line hidden
            EndContext();
            BeginContext(294, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(350, 41, false);
#line 17 "D:\Mahavir Backup\Projects\DataManagement\Source\DataMangement\Views\Home\GetYearData.cshtml"
           Write(Html.DisplayNameFor(model => model.month));

#line default
#line hidden
            EndContext();
            BeginContext(391, 86, true);
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 23 "D:\Mahavir Backup\Projects\DataManagement\Source\DataMangement\Views\Home\GetYearData.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
            BeginContext(509, 48, true);
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(558, 39, false);
#line 26 "D:\Mahavir Backup\Projects\DataManagement\Source\DataMangement\Views\Home\GetYearData.cshtml"
           Write(Html.DisplayFor(modelItem => item.year));

#line default
#line hidden
            EndContext();
            BeginContext(597, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(653, 40, false);
#line 29 "D:\Mahavir Backup\Projects\DataManagement\Source\DataMangement\Views\Home\GetYearData.cshtml"
           Write(Html.DisplayFor(modelItem => item.month));

#line default
#line hidden
            EndContext();
            BeginContext(693, 49, true);
            WriteLiteral("\r\n            </td>\r\n           \r\n        </tr>\r\n");
            EndContext();
#line 33 "D:\Mahavir Backup\Projects\DataManagement\Source\DataMangement\Views\Home\GetYearData.cshtml"
}

#line default
#line hidden
            BeginContext(745, 24, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Dm.Common.Models.YearTree>> Html { get; private set; }
    }
}
#pragma warning restore 1591
