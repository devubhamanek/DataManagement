#pragma checksum "D:\Mahavir Backup\Projects\DataManagement\Source\DataMangement\Views\Hardik\HkP.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "878f904bb500296a434a0f03c3c684b01553c038"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Hardik_HkP), @"mvc.1.0.view", @"/Views/Hardik/HkP.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Hardik/HkP.cshtml", typeof(AspNetCore.Views_Hardik_HkP))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"878f904bb500296a434a0f03c3c684b01553c038", @"/Views/Hardik/HkP.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"11c19027dae96b3018eb40aaa421f92aa78d3222", @"/Views/_ViewImports.cshtml")]
    public class Views_Hardik_HkP : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "D:\Mahavir Backup\Projects\DataManagement\Source\DataMangement\Views\Hardik\HkP.cshtml"
  
    string Name = ViewData["Test"].ToString();

#line default
#line hidden
            BeginContext(57, 30, true);
            WriteLiteral("\r\n<h2>HkP</h2>\r\n\r\n<h1>Hi .... ");
            EndContext();
            BeginContext(88, 4, false);
#line 8 "D:\Mahavir Backup\Projects\DataManagement\Source\DataMangement\Views\Hardik\HkP.cshtml"
       Write(Name);

#line default
#line hidden
            EndContext();
            BeginContext(92, 10, true);
            WriteLiteral(" </h1>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
