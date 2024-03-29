#pragma checksum "C:\Users\eyuph\source\repos\FarmasiCaseDemo\FarmasiDemo.WebApp\Views\Home\Products.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "43611a72b023fe813141029b6c5381b210e9684b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Products), @"mvc.1.0.view", @"/Views/Home/Products.cshtml")]
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
#line 1 "C:\Users\eyuph\source\repos\FarmasiCaseDemo\FarmasiDemo.WebApp\Views\_ViewImports.cshtml"
using FarmasiDemo.WebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\eyuph\source\repos\FarmasiCaseDemo\FarmasiDemo.WebApp\Views\_ViewImports.cshtml"
using FarmasiDemo.WebApp.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\eyuph\source\repos\FarmasiCaseDemo\FarmasiDemo.WebApp\Views\Home\Products.cshtml"
using FarmasiDemo.Models.Concrete;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"43611a72b023fe813141029b6c5381b210e9684b", @"/Views/Home/Products.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"59b81489af0c645154e7f432531782b39d5321c3", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Products : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<ProductDto>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("<div class=\"row p-0 mt-4\">\r\n\r\n");
#nullable restore
#line 8 "C:\Users\eyuph\source\repos\FarmasiCaseDemo\FarmasiDemo.WebApp\Views\Home\Products.cshtml"
     foreach (var item in Model)
    {


#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"card text-center col-md-3\">\r\n            <div class=\"card-header fs-20 font-weight-bolder\">\r\n                ");
#nullable restore
#line 13 "C:\Users\eyuph\source\repos\FarmasiCaseDemo\FarmasiDemo.WebApp\Views\Home\Products.cshtml"
           Write(item.ProductName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            <div class=\"card-body\">\r\n                <h5 class=\"card-title\">");
#nullable restore
#line 16 "C:\Users\eyuph\source\repos\FarmasiCaseDemo\FarmasiDemo.WebApp\Views\Home\Products.cshtml"
                                  Write(item.UnitPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("₺</h5>\r\n                <p class=\"card-text\">Pakette ");
#nullable restore
#line 17 "C:\Users\eyuph\source\repos\FarmasiCaseDemo\FarmasiDemo.WebApp\Views\Home\Products.cshtml"
                                        Write(item.QuantityPerUnit);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ürün vardır.</p>\r\n                <Button class=\"btn btn-primary\"");
            BeginWriteAttribute("onclick", " onclick=\"", 547, "\"", 578, 3);
            WriteAttributeValue("", 557, "addToCart(\'", 557, 11, true);
#nullable restore
#line 18 "C:\Users\eyuph\source\repos\FarmasiCaseDemo\FarmasiDemo.WebApp\Views\Home\Products.cshtml"
WriteAttributeValue("", 568, item.Id, 568, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 576, "\')", 576, 2, true);
            EndWriteAttribute();
            WriteLiteral(">Sepete Ekle</Button>\r\n            </div>\r\n            <div class=\"card-footer text-muted\">\r\n");
#nullable restore
#line 21 "C:\Users\eyuph\source\repos\FarmasiCaseDemo\FarmasiDemo.WebApp\Views\Home\Products.cshtml"
                 if (item.UnitsInStock == 0)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <span>Stok Tükendi.</span>\r\n");
#nullable restore
#line 24 "C:\Users\eyuph\source\repos\FarmasiCaseDemo\FarmasiDemo.WebApp\Views\Home\Products.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <span>Stokta ");
#nullable restore
#line 27 "C:\Users\eyuph\source\repos\FarmasiCaseDemo\FarmasiDemo.WebApp\Views\Home\Products.cshtml"
                            Write(item.UnitsInStock);

#line default
#line hidden
#nullable disable
            WriteLiteral(" adet vardır.</span>\r\n");
#nullable restore
#line 28 "C:\Users\eyuph\source\repos\FarmasiCaseDemo\FarmasiDemo.WebApp\Views\Home\Products.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 32 "C:\Users\eyuph\source\repos\FarmasiCaseDemo\FarmasiDemo.WebApp\Views\Home\Products.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n<script>\r\n    function addToCart(productId) {\r\n        $.ajax({\r\n            type: \"POST\",\r\n            data: { productId: productId },\r\n            url: \"");
#nullable restore
#line 39 "C:\Users\eyuph\source\repos\FarmasiCaseDemo\FarmasiDemo.WebApp\Views\Home\Products.cshtml"
             Write(Url.Action("AddCartAjaxPop", "Home"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@""",
            success: function(result) {
                if (result.success) {
                    $(""#basket-items"").empty();
                    result.data.forEach((item) => {
                        $(""#basket-items"").append(`<a class='dropdown-item'>${item.product.productName}</a><span class=""ml-2""> Miktar : ${item.quantity}</span><hr>`);
                    })
                    if (result.data.length == 0) {
                        $(""#basket-info"").html(`Sepetinizde ürün bulunmamaktadır.`);
                    }
                    else {
                        $(""#basket-info"").html(`Sepetinizde ${result.data.length} ürün bulunmaktadır.`);
                    }
                }
                else {

                }
            }
        })
    }
</script>
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<ProductDto>> Html { get; private set; }
    }
}
#pragma warning restore 1591
