#pragma checksum "F:\myecommerceapi\ecommerceapi\src\Modules\SimplCommerce.Module.Catalog\Areas\Catalog\Views\Shared\_ProductThumbnail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5928098fa9fa3b3d05ce643fe40c9a04550157d4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Catalog_Views_Shared__ProductThumbnail), @"mvc.1.0.view", @"/Areas/Catalog/Views/Shared/_ProductThumbnail.cshtml")]
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
#line 1 "F:\myecommerceapi\ecommerceapi\src\Modules\SimplCommerce.Module.Catalog\Areas\Catalog\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\myecommerceapi\ecommerceapi\src\Modules\SimplCommerce.Module.Catalog\Areas\Catalog\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Mvc.Localization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "F:\myecommerceapi\ecommerceapi\src\Modules\SimplCommerce.Module.Catalog\Areas\Catalog\Views\_ViewImports.cshtml"
using Microsoft.Extensions.Configuration;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5928098fa9fa3b3d05ce643fe40c9a04550157d4", @"/Areas/Catalog/Views/Shared/_ProductThumbnail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2aebbfeca66281e74576e81f6750e98ca764629d", @"/Areas/Catalog/Views/_ViewImports.cshtml")]
    public class Areas_Catalog_Views_Shared__ProductThumbnail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SimplCommerce.Module.Catalog.Areas.Catalog.ViewModels.ProductThumbnail>
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"card mb-4\">\r\n    <input type=\"hidden\" id=\"productId\"");
            BeginWriteAttribute("value", " value=\"", 145, "\"", 162, 1);
#nullable restore
#line 4 "F:\myecommerceapi\ecommerceapi\src\Modules\SimplCommerce.Module.Catalog\Areas\Catalog\Views\Shared\_ProductThumbnail.cshtml"
WriteAttributeValue("", 153, Model.Id, 153, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5928098fa9fa3b3d05ce643fe40c9a04550157d44143", async() => {
                WriteLiteral("\r\n        <img");
                BeginWriteAttribute("alt", " alt=\"", 210, "\"", 227, 1);
#nullable restore
#line 6 "F:\myecommerceapi\ecommerceapi\src\Modules\SimplCommerce.Module.Catalog\Areas\Catalog\Views\Shared\_ProductThumbnail.cshtml"
WriteAttributeValue("", 216, Model.Name, 216, 11, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"card-img-top\"");
                BeginWriteAttribute("src", " src=\"", 249, "\"", 274, 1);
#nullable restore
#line 6 "F:\myecommerceapi\ecommerceapi\src\Modules\SimplCommerce.Module.Catalog\Areas\Catalog\Views\Shared\_ProductThumbnail.cshtml"
WriteAttributeValue("", 255, Model.ThumbnailUrl, 255, 19, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n        <div class=\"card-body\">\r\n            <h5 class=\"card-title product-name\">");
#nullable restore
#line 8 "F:\myecommerceapi\ecommerceapi\src\Modules\SimplCommerce.Module.Catalog\Areas\Catalog\Views\Shared\_ProductThumbnail.cshtml"
                                           Write(Model.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h5>\r\n            <p class=\"card-text product-price\">\r\n");
#nullable restore
#line 10 "F:\myecommerceapi\ecommerceapi\src\Modules\SimplCommerce.Module.Catalog\Areas\Catalog\Views\Shared\_ProductThumbnail.cshtml"
                 if (Model.IsCallForPricing)
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "F:\myecommerceapi\ecommerceapi\src\Modules\SimplCommerce.Module.Catalog\Areas\Catalog\Views\Shared\_ProductThumbnail.cshtml"
               Write(Localizer["Call for pricing"]);

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "F:\myecommerceapi\ecommerceapi\src\Modules\SimplCommerce.Module.Catalog\Areas\Catalog\Views\Shared\_ProductThumbnail.cshtml"
                                                  
                }
                else
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "F:\myecommerceapi\ecommerceapi\src\Modules\SimplCommerce.Module.Catalog\Areas\Catalog\Views\Shared\_ProductThumbnail.cshtml"
               Write(Model.CalculatedProductPrice.PriceString);

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "F:\myecommerceapi\ecommerceapi\src\Modules\SimplCommerce.Module.Catalog\Areas\Catalog\Views\Shared\_ProductThumbnail.cshtml"
                                                             
                    if (Model.CalculatedProductPrice.PercentOfSaving > 0)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <span class=\"product-price-saving\">-");
#nullable restore
#line 19 "F:\myecommerceapi\ecommerceapi\src\Modules\SimplCommerce.Module.Catalog\Areas\Catalog\Views\Shared\_ProductThumbnail.cshtml"
                                                        Write(Model.CalculatedProductPrice.PercentOfSaving);

#line default
#line hidden
#nullable disable
                WriteLiteral("%</span>\r\n                        <br />\r\n                        <span class=\"product-price-regular\">");
#nullable restore
#line 21 "F:\myecommerceapi\ecommerceapi\src\Modules\SimplCommerce.Module.Catalog\Areas\Catalog\Views\Shared\_ProductThumbnail.cshtml"
                                                       Write(Model.CalculatedProductPrice.OldPriceString);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>\r\n");
#nullable restore
#line 22 "F:\myecommerceapi\ecommerceapi\src\Modules\SimplCommerce.Module.Catalog\Areas\Catalog\Views\Shared\_ProductThumbnail.cshtml"
                    }
                }

#line default
#line hidden
#nullable disable
                WriteLiteral("            </p>\r\n            <ul class=\"list-inline product-ratings\">\r\n                <li><input type=\"hidden\"");
                BeginWriteAttribute("value", " value=\"", 1180, "\"", 1208, 1);
#nullable restore
#line 26 "F:\myecommerceapi\ecommerceapi\src\Modules\SimplCommerce.Module.Catalog\Areas\Catalog\Views\Shared\_ProductThumbnail.cshtml"
WriteAttributeValue("", 1188, Model.RatingAverage, 1188, 20, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" readonly=\"readonly\" class=\"rating-loading\" step=\"1\" data-size=\"xs\" data-show-clear=\"false\" data-show-caption=\"false\" /></li>\r\n");
#nullable restore
#line 27 "F:\myecommerceapi\ecommerceapi\src\Modules\SimplCommerce.Module.Catalog\Areas\Catalog\Views\Shared\_ProductThumbnail.cshtml"
                 if (Model.ReviewsCount > 0)
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <li class=\"product-review-list\">\r\n                        <span>(");
#nullable restore
#line 30 "F:\myecommerceapi\ecommerceapi\src\Modules\SimplCommerce.Module.Catalog\Areas\Catalog\Views\Shared\_ProductThumbnail.cshtml"
                          Write(Model.ReviewsCount);

#line default
#line hidden
#nullable disable
                WriteLiteral(" ");
#nullable restore
#line 30 "F:\myecommerceapi\ecommerceapi\src\Modules\SimplCommerce.Module.Catalog\Areas\Catalog\Views\Shared\_ProductThumbnail.cshtml"
                                              Write(Localizer["reviews"]);

#line default
#line hidden
#nullable disable
                WriteLiteral(")</span>\r\n                    </li>\r\n");
#nullable restore
#line 32 "F:\myecommerceapi\ecommerceapi\src\Modules\SimplCommerce.Module.Catalog\Areas\Catalog\Views\Shared\_ProductThumbnail.cshtml"
                }

#line default
#line hidden
#nullable disable
                WriteLiteral("            </ul>\r\n\r\n        </div>\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 181, "~/", 181, 2, true);
#nullable restore
#line 5 "F:\myecommerceapi\ecommerceapi\src\Modules\SimplCommerce.Module.Catalog\Areas\Catalog\Views\Shared\_ProductThumbnail.cshtml"
AddHtmlAttributeValue("", 183, Model.Slug, 183, 11, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IConfiguration AppSetting { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IViewLocalizer Localizer { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SimplCommerce.Module.Catalog.Areas.Catalog.ViewModels.ProductThumbnail> Html { get; private set; }
    }
}
#pragma warning restore 1591
