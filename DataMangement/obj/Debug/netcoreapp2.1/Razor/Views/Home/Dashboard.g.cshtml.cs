#pragma checksum "D:\Mahavir Backup\Projects\DataManagement\Source\DataMangement\Views\Home\Dashboard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "33fcbeecf363515c93a2f17cc67196456225dc54"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Dashboard), @"mvc.1.0.view", @"/Views/Home/Dashboard.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Dashboard.cshtml", typeof(AspNetCore.Views_Home_Dashboard))]
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
#line 1 "D:\Mahavir Backup\Projects\DataManagement\Source\DataMangement\Views\Home\Dashboard.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"33fcbeecf363515c93a2f17cc67196456225dc54", @"/Views/Home/Dashboard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"11c19027dae96b3018eb40aaa421f92aa78d3222", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Dashboard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(111, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 4 "D:\Mahavir Backup\Projects\DataManagement\Source\DataMangement\Views\Home\Dashboard.cshtml"
  
    ViewBag.Title = "Dashboard";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(201, 44, true);
            WriteLiteral("<!doctype html>\r\n<html ng-app=\"mymodal\">\r\n\r\n");
            EndContext();
            BeginContext(245, 3410, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dc606b44a116469199924946e72c977f", async() => {
                BeginContext(251, 231, true);
                WriteLiteral("\r\n    <div id=\"page-wraper\" style=\"min-height:570px;\">\r\n        <div class=\"container\">\r\n\r\n            <div class=\"row\">\r\n                <div class=\"col-md-12\">\r\n\r\n                    <h1>  <span class=\"\">Dashboard</span></h1>\r\n\r\n");
                EndContext();
#line 20 "D:\Mahavir Backup\Projects\DataManagement\Source\DataMangement\Views\Home\Dashboard.cshtml"
                     if (TempData["Success"] != null)
                    {

#line default
#line hidden
                BeginContext(560, 115, true);
                WriteLiteral("                        <p class=\"alert-success\" style=\"padding: 5px;\"><i class=\"glyphicon glyphicon-ok\">&nbsp;</i>");
                EndContext();
                BeginContext(676, 19, false);
#line 22 "D:\Mahavir Backup\Projects\DataManagement\Source\DataMangement\Views\Home\Dashboard.cshtml"
                                                                                                              Write(TempData["Success"]);

#line default
#line hidden
                EndContext();
                BeginContext(695, 6, true);
                WriteLiteral("</p>\r\n");
                EndContext();
#line 23 "D:\Mahavir Backup\Projects\DataManagement\Source\DataMangement\Views\Home\Dashboard.cshtml"
                    }

#line default
#line hidden
                BeginContext(724, 76, true);
                WriteLiteral("                    <hr />\r\n                </div>\r\n                <br />\r\n");
                EndContext();
                BeginContext(3598, 50, true);
                WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3655, 19, true);
            WriteLiteral("\r\n</html>\r\n\r\n\r\n\r\n\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Microsoft.AspNetCore.Http.IHttpContextAccessor HttpContextAccessor { get; private set; }
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
