#pragma checksum "C:\Users\L2L\source\repos\Lyzic\Views\First\ViewProduct2.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c495a87e75e1169eaf128680f60244be516f5a78"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_First_ViewProduct2), @"mvc.1.0.view", @"/Views/First/ViewProduct2.cshtml")]
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
#line 1 "C:\Users\L2L\source\repos\Lyzic\Views\_ViewImports.cshtml"
using Lyzic;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\L2L\source\repos\Lyzic\Views\_ViewImports.cshtml"
using Lyzic.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c495a87e75e1169eaf128680f60244be516f5a78", @"/Views/First/ViewProduct2.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cb2d5ea96369de67fa0d67191c3e75b5a0e1ff1e", @"/Views/_ViewImports.cshtml")]
    public class Views_First_ViewProduct2 : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Lyzic.Models.ProductModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\L2L\source\repos\Lyzic\Views\First\ViewProduct2.cshtml"
  
    var product = ViewData["product"] as ProductModel;

#line default
#line hidden
#nullable disable
            WriteLiteral("<div>\r\n    ");
#nullable restore
#line 6 "C:\Users\L2L\source\repos\Lyzic\Views\First\ViewProduct2.cshtml"
Write(product.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <br>\r\n    ");
#nullable restore
#line 8 "C:\Users\L2L\source\repos\Lyzic\Views\First\ViewProduct2.cshtml"
Write(product.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Lyzic.Models.ProductModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
