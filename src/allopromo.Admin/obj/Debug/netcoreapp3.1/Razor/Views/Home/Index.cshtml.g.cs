#pragma checksum "C:\Users\MonPC\source\repos\allopromo\allopromo.Admin\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "842ee265b631f4b95b4627d025a66e23c8908dbb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "C:\Users\MonPC\source\repos\allopromo\allopromo.Admin\Views\_ViewImports.cshtml"
using allopromo.Administration;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\MonPC\source\repos\allopromo\allopromo.Admin\Views\_ViewImports.cshtml"
using allopromo.Administration.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"842ee265b631f4b95b4627d025a66e23c8908dbb", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"574345da1491d1503f1a2a2dc7a90957677db7cd", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<allopromo.Admin.Models.Dto.CategoryDto>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\MonPC\source\repos\allopromo\allopromo.Admin\Views\Home\Index.cshtml"
  
    Layout = "../Shared/Admin/_AdminLayout";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""col-md-9"">
    <h3 class=""display-4"" style=""background-color:beige;margin-top:5px"">hello Admin </h3> <!--honeydew - beige darkgreen-->
    <div style=""border-style:dotted;background-color:#fefbfb"">
        <h4>Administration Cat&eacute;gories </h4>
");
#nullable restore
#line 9 "C:\Users\MonPC\source\repos\allopromo\allopromo.Admin\Views\Home\Index.cshtml"
         foreach (var category in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div>");
#nullable restore
#line 11 "C:\Users\MonPC\source\repos\allopromo\allopromo.Admin\Views\Home\Index.cshtml"
            Write(category.categoryId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n            <div>");
#nullable restore
#line 12 "C:\Users\MonPC\source\repos\allopromo\allopromo.Admin\Views\Home\Index.cshtml"
            Write(category.categoryName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n            <div>");
#nullable restore
#line 13 "C:\Users\MonPC\source\repos\allopromo\allopromo.Admin\Views\Home\Index.cshtml"
            Write(category.catThumbnail);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
#nullable restore
#line 14 "C:\Users\MonPC\source\repos\allopromo\allopromo.Admin\Views\Home\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<allopromo.Admin.Models.Dto.CategoryDto>> Html { get; private set; }
    }
}
#pragma warning restore 1591
