#pragma checksum "C:\Users\MonPC\source\repos\allopromo\allopromo.Admin\Views\Account\Login.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "799b774d68879ff73066900a7670e9aec84ffa75"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_Login), @"mvc.1.0.view", @"/Views/Account/Login.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"799b774d68879ff73066900a7670e9aec84ffa75", @"/Views/Account/Login.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"574345da1491d1503f1a2a2dc7a90957677db7cd", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_Login : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\MonPC\source\repos\allopromo\allopromo.Admin\Views\Account\Login.cshtml"
  
    Layout = "../Shared/_Layout";

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\MonPC\source\repos\allopromo\allopromo.Admin\Views\Account\Login.cshtml"
  
    ViewData["Title"] = "Login";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"text-center\">\r\n    <h1 class=\"display-4\" style=\"background-color:darkgreen\">Login Admin s</h1>\r\n    <div");
            BeginWriteAttribute("class", " class=\"", 199, "\"", 207, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n        <h3 class=\"display-4\" style=\"background-color:beige;margin-top:5px\">hello Admin </h3> <!--honeydew - beige darkgreen-->\r\n        <div style=\"border-style:;background-color:#fefbfb\">\r\n");
#nullable restore
#line 12 "C:\Users\MonPC\source\repos\allopromo\allopromo.Admin\Views\Account\Login.cshtml"
             using (Html.BeginForm("Index", "Home", FormMethod.Post))
            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <div class=""form-group"">
                    <label for=""firstname"" class=""col-sm-2 control-label"">Pr&eacute;nom </label>
                    <div class=""col-sm-10"">
                        <input type=""text"" class=""form-control"" id=""firstname""
                               placeholder=""Enter First Name"">
                    </div>
                </div>
                <div class=""form-group"">
                    <label for=""lastname"" class=""col-sm-2 control-label"">Nom</label>
                    <div class=""col-sm-10"">
                        <input type=""text"" class=""form-control"" id=""lastname""
                               placeholder=""Enter Last Name"">
                    </div>
                </div>
                <div class=""form-group"">
                    <div class=""col-sm-offset-2 col-sm-10"">
                        <div class=""checkbox"">
                            <label>
                                <input type=""checkbox""> Enregistrez-moi
               ");
            WriteLiteral(@"             </label>
                        </div>
                    </div>
                </div>
                <div class=""form-group"">
                    <div class=""col-sm-offset-2 col-sm-10"">
                        <button type=""submit"" class=""btn btn-default"" style=""background-color:seagreen;color:#fff"">
                            Connection
                        </button>

                    </div>
                </div>
");
#nullable restore
#line 45 "C:\Users\MonPC\source\repos\allopromo\allopromo.Admin\Views\Account\Login.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        </div>
    </div>
</div>
<!--honeydew - beige darkgreen-->
<!--
    <div style=""background-color:beige"">
        <form class=""form-horizontal"" role=""form"">
            <div class=""form-group"">
                <label for=""firstname"" class=""col-sm-2 control-label"">Pr&eacute;nom </label>
                <div class=""col-sm-10"">
                    <input type=""text"" class=""form-control"" id=""firstname""
                           placeholder=""Enter First Name"">
                </div>
            </div>
            <div class=""form-group"">
                <label for=""lastname"" class=""col-sm-2 control-label"">Nom</label>
                <div class=""col-sm-10"">
                    <input type=""text"" class=""form-control"" id=""lastname""
                           placeholder=""Enter Last Name"">
                </div>
            </div>
            <div class=""form-group"">
                <div class=""col-sm-offset-2 col-sm-10"">
                    <div class=""checkbox"">
                      ");
            WriteLiteral(@"  <label>
                            <input type=""checkbox""> Enregistrez-moi
                        </label>
                    </div>
                </div>
            </div>
            <div class=""form-group"">
                <div class=""col-sm-offset-2 col-sm-10"">
                    <button type=""submit"" class=""btn btn-default"" style=""background-color:green"">Connection</button>
                </div>
            </div>
        </form>
    </div>
</div>Layout = ""~/Admin/AdminLayout"";
-->
");
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
