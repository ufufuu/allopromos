#pragma checksum "C:\Users\MonPC\source\repos\allopromo\allopromo.Admin\Views\Department\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ee1231791fc81428e078ba969b5bd010c4b4569c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Department_Index), @"mvc.1.0.view", @"/Views/Department/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ee1231791fc81428e078ba969b5bd010c4b4569c", @"/Views/Department/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"574345da1491d1503f1a2a2dc7a90957677db7cd", @"/Views/_ViewImports.cshtml")]
    public class Views_Department_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<allopromo.Admin.Models.Dto.DepartmentDto>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\MonPC\source\repos\allopromo\allopromo.Admin\Views\Department\Index.cshtml"
  
    Layout = "../Shared/Admin/_AdminLayout";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"text-center\">\r\n    <h1 class=\"display-4\" style=\"background-color:darkgreen\">Departement List</h1>\r\n    <div");
            BeginWriteAttribute("class", " class=\"", 234, "\"", 242, 0);
            EndWriteAttribute();
            WriteLiteral(@">
        <h3 class=""display-4"" style=""background-color:beige;margin-top:5px"">Department Info </h3>
        <div style=""border-style:;background-color:#fefbfb"">
            <table>
                <tr>
                    <th>
                        Genre
                    </th>
                    <th>
                        Artist
                    </th>
                    <th>
                        Title
                    </th>
                    <th>
                        Price
                    </th>
                    <th>
                        AlbumArtUrl
                    </th>
                    <th></th>
                </tr>
");
#nullable restore
#line 29 "C:\Users\MonPC\source\repos\allopromo\allopromo.Admin\Views\Department\Index.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
#nullable restore
#line 33 "C:\Users\MonPC\source\repos\allopromo\allopromo.Admin\Views\Department\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.departmentId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 36 "C:\Users\MonPC\source\repos\allopromo\allopromo.Admin\Views\Department\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.departmentName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 39 "C:\Users\MonPC\source\repos\allopromo\allopromo.Admin\Views\Department\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.departmentId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 42 "C:\Users\MonPC\source\repos\allopromo\allopromo.Admin\Views\Department\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.departmentName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 45 "C:\Users\MonPC\source\repos\allopromo\allopromo.Admin\Views\Department\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.departmentName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 48 "C:\Users\MonPC\source\repos\allopromo\allopromo.Admin\Views\Department\Index.cshtml"
                       Write(Html.ActionLink("Edit", "Edit", new { id = item.departmentName }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                            ");
#nullable restore
#line 49 "C:\Users\MonPC\source\repos\allopromo\allopromo.Admin\Views\Department\Index.cshtml"
                       Write(Html.ActionLink("Details", "Details", new { id = item.departmentName }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                            ");
#nullable restore
#line 50 "C:\Users\MonPC\source\repos\allopromo\allopromo.Admin\Views\Department\Index.cshtml"
                       Write(Html.ActionLink("Delete", "Delete", new { id = item.departmentName }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 53 "C:\Users\MonPC\source\repos\allopromo\allopromo.Admin\Views\Department\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </table>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<allopromo.Admin.Models.Dto.DepartmentDto>> Html { get; private set; }
    }
}
#pragma warning restore 1591
