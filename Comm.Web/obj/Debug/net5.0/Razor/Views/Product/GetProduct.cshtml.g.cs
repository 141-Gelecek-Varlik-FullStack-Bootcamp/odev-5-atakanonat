#pragma checksum "/Users/atakanonat/dev/C#/odev-4/Comm.Web/Views/Product/GetProduct.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9490ac92f62c0b10f82760c0f470b82a769fbdd8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_GetProduct), @"mvc.1.0.view", @"/Views/Product/GetProduct.cshtml")]
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
#line 1 "/Users/atakanonat/dev/C#/odev-4/Comm.Web/Views/_ViewImports.cshtml"
using Comm.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/atakanonat/dev/C#/odev-4/Comm.Web/Views/_ViewImports.cshtml"
using Comm.Web.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "/Users/atakanonat/dev/C#/odev-4/Comm.Web/Views/Product/GetProduct.cshtml"
using Comm.Model.Product;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9490ac92f62c0b10f82760c0f470b82a769fbdd8", @"/Views/Product/GetProduct.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ab75a6a5f961dca7e7c0dce95c695c57b06511f6", @"/Views/_ViewImports.cshtml")]
    public class Views_Product_GetProduct : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Product>
    {
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
#nullable restore
#line 3 "/Users/atakanonat/dev/C#/odev-4/Comm.Web/Views/Product/GetProduct.cshtml"
  
    var Product = (Product)ViewBag.Product;
    ViewData["title"] = Product.Name;

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9490ac92f62c0b10f82760c0f470b82a769fbdd83412", async() => {
                WriteLiteral("\n    <h2>Product: ");
#nullable restore
#line 9 "/Users/atakanonat/dev/C#/odev-4/Comm.Web/Views/Product/GetProduct.cshtml"
            Write(Product.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h2>\n    <ul>\n        <li>\n            <p><b>Description: </b>");
#nullable restore
#line 12 "/Users/atakanonat/dev/C#/odev-4/Comm.Web/Views/Product/GetProduct.cshtml"
                              Write(Product.Description);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\n        </li>\n        <li>\n            <p><b>Stock: </b>");
#nullable restore
#line 15 "/Users/atakanonat/dev/C#/odev-4/Comm.Web/Views/Product/GetProduct.cshtml"
                        Write(Product.Stock);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\n        </li>\n        <li>\n            <p><b>Price: </b>");
#nullable restore
#line 18 "/Users/atakanonat/dev/C#/odev-4/Comm.Web/Views/Product/GetProduct.cshtml"
                        Write(Product.Price);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\n        </li>\n    </ul>\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Product> Html { get; private set; }
    }
}
#pragma warning restore 1591
