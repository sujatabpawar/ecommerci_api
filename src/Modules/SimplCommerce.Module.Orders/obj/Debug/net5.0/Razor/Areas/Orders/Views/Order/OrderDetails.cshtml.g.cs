#pragma checksum "H:\Client\SimplCommerce\src\Modules\SimplCommerce.Module.Orders\Areas\Orders\Views\Order\OrderDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "859503a0485b5669a9be1d64f82a56df2244c4fc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Orders_Views_Order_OrderDetails), @"mvc.1.0.view", @"/Areas/Orders/Views/Order/OrderDetails.cshtml")]
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
#line 1 "H:\Client\SimplCommerce\src\Modules\SimplCommerce.Module.Orders\Areas\Orders\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "H:\Client\SimplCommerce\src\Modules\SimplCommerce.Module.Orders\Areas\Orders\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Mvc.Localization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "H:\Client\SimplCommerce\src\Modules\SimplCommerce.Module.Orders\Areas\Orders\Views\_ViewImports.cshtml"
using SimplCommerce.Module.Core.Extensions;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"859503a0485b5669a9be1d64f82a56df2244c4fc", @"/Areas/Orders/Views/Order/OrderDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"abf3e0405f4495e5df7ddc371fbf1bfd277f4556", @"/Areas/Orders/Views/_ViewImports.cshtml")]
    public class Areas_Orders_Views_Order_OrderDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SimplCommerce.Module.Orders.Areas.Orders.ViewModels.OrderDetailVm>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_AccountMenu", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "H:\Client\SimplCommerce\src\Modules\SimplCommerce.Module.Orders\Areas\Orders\Views\Order\OrderDetails.cshtml"
  
    ViewData["Title"] = Localizer["Order detail"];

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"col-md-3\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "859503a0485b5669a9be1d64f82a56df2244c4fc4206", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n    <div class=\"col-md-9\">\r\n        <div class=\"row\">\r\n            <div class=\"col-md-7\">\r\n                <h5>");
#nullable restore
#line 14 "H:\Client\SimplCommerce\src\Modules\SimplCommerce.Module.Orders\Areas\Orders\Views\Order\OrderDetails.cshtml"
               Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 14 "H:\Client\SimplCommerce\src\Modules\SimplCommerce.Module.Orders\Areas\Orders\Views\Order\OrderDetails.cshtml"
                                  Write(Model.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 14 "H:\Client\SimplCommerce\src\Modules\SimplCommerce.Module.Orders\Areas\Orders\Views\Order\OrderDetails.cshtml"
                                              Write(Localizer[Model.OrderStatusString]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n            </div>\r\n            <div class=\"col-md-5 text-right\">\r\n                ");
#nullable restore
#line 17 "H:\Client\SimplCommerce\src\Modules\SimplCommerce.Module.Orders\Areas\Orders\Views\Order\OrderDetails.cshtml"
           Write(Localizer["Order date"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 17 "H:\Client\SimplCommerce\src\Modules\SimplCommerce.Module.Orders\Areas\Orders\Views\Order\OrderDetails.cshtml"
                                    Write(Model.CreatedOn.DateTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div class=\"row mt-4\">\r\n            <div class=\"col-md-4\"><strong>");
#nullable restore
#line 21 "H:\Client\SimplCommerce\src\Modules\SimplCommerce.Module.Orders\Areas\Orders\Views\Order\OrderDetails.cshtml"
                                     Write(Localizer["Shipping address"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong></div>\r\n            <div class=\"col-md-4\"><strong>");
#nullable restore
#line 22 "H:\Client\SimplCommerce\src\Modules\SimplCommerce.Module.Orders\Areas\Orders\Views\Order\OrderDetails.cshtml"
                                     Write(Localizer["Shipping method"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong></div>\r\n            <div class=\"col-md-4\"><strong>");
#nullable restore
#line 23 "H:\Client\SimplCommerce\src\Modules\SimplCommerce.Module.Orders\Areas\Orders\Views\Order\OrderDetails.cshtml"
                                     Write(Localizer["Payment method"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong></div>\r\n        </div>\r\n        <div class=\"row\">\r\n            <div class=\"col-md-4\">\r\n                <strong>");
#nullable restore
#line 27 "H:\Client\SimplCommerce\src\Modules\SimplCommerce.Module.Orders\Areas\Orders\Views\Order\OrderDetails.cshtml"
                   Write(Model.ShippingAddress.ContactName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong> <br />\r\n                ");
#nullable restore
#line 28 "H:\Client\SimplCommerce\src\Modules\SimplCommerce.Module.Orders\Areas\Orders\Views\Order\OrderDetails.cshtml"
           Write(Model.ShippingAddress.AddressLine1);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <br />\r\n                ");
#nullable restore
#line 29 "H:\Client\SimplCommerce\src\Modules\SimplCommerce.Module.Orders\Areas\Orders\Views\Order\OrderDetails.cshtml"
           Write(Model.ShippingAddress.AddressLine2);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <br />\r\n                ");
#nullable restore
#line 30 "H:\Client\SimplCommerce\src\Modules\SimplCommerce.Module.Orders\Areas\Orders\Views\Order\OrderDetails.cshtml"
           Write(Localizer["Phone"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(": ");
#nullable restore
#line 30 "H:\Client\SimplCommerce\src\Modules\SimplCommerce.Module.Orders\Areas\Orders\Views\Order\OrderDetails.cshtml"
                                Write(Model.ShippingAddress.Phone);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            <div class=\"col-md-4\">");
#nullable restore
#line 32 "H:\Client\SimplCommerce\src\Modules\SimplCommerce.Module.Orders\Areas\Orders\Views\Order\OrderDetails.cshtml"
                             Write(Model.ShippingMethod);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n            <div class=\"col-md-4\">");
#nullable restore
#line 33 "H:\Client\SimplCommerce\src\Modules\SimplCommerce.Module.Orders\Areas\Orders\Views\Order\OrderDetails.cshtml"
                             Write(Localizer[Model.PaymentMethod]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n        </div>\r\n\r\n        <table class=\"table table-borderless mt-4\">\r\n            <thead>\r\n                <tr>\r\n                    <th class=\"pl-0\">");
#nullable restore
#line 39 "H:\Client\SimplCommerce\src\Modules\SimplCommerce.Module.Orders\Areas\Orders\Views\Order\OrderDetails.cshtml"
                                Write(Localizer["Product"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                    <th class=\"text-right\">");
#nullable restore
#line 40 "H:\Client\SimplCommerce\src\Modules\SimplCommerce.Module.Orders\Areas\Orders\Views\Order\OrderDetails.cshtml"
                                      Write(Localizer["Price"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                    <th class=\"text-right\">");
#nullable restore
#line 41 "H:\Client\SimplCommerce\src\Modules\SimplCommerce.Module.Orders\Areas\Orders\Views\Order\OrderDetails.cshtml"
                                      Write(Localizer["Quantity"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                    <th class=\"text-right\">");
#nullable restore
#line 42 "H:\Client\SimplCommerce\src\Modules\SimplCommerce.Module.Orders\Areas\Orders\Views\Order\OrderDetails.cshtml"
                                      Write(Localizer["Discount"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                    <th class=\"text-right text-nowrap pr-0\">");
#nullable restore
#line 43 "H:\Client\SimplCommerce\src\Modules\SimplCommerce.Module.Orders\Areas\Orders\Views\Order\OrderDetails.cshtml"
                                                       Write(Localizer["Row Total"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                </tr>\r\n            </thead>\r\n            <tbody>\r\n");
#nullable restore
#line 47 "H:\Client\SimplCommerce\src\Modules\SimplCommerce.Module.Orders\Areas\Orders\Views\Order\OrderDetails.cshtml"
                 foreach (var item in Model.OrderItems)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td class=\"pl-0\">\r\n                            <div class=\"row\">\r\n                                <div class=\"col-md-3\">\r\n                                    <img class=\"img-fluid\"");
            BeginWriteAttribute("src", " src=\"", 2240, "\"", 2264, 1);
#nullable restore
#line 53 "H:\Client\SimplCommerce\src\Modules\SimplCommerce.Module.Orders\Areas\Orders\Views\Order\OrderDetails.cshtml"
WriteAttributeValue("", 2246, item.ProductImage, 2246, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                                </div>\r\n                                <div class=\"col-md-9\">\r\n                                    <p>");
#nullable restore
#line 56 "H:\Client\SimplCommerce\src\Modules\SimplCommerce.Module.Orders\Areas\Orders\Views\Order\OrderDetails.cshtml"
                                  Write(item.ProductName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                    <p>");
#nullable restore
#line 57 "H:\Client\SimplCommerce\src\Modules\SimplCommerce.Module.Orders\Areas\Orders\Views\Order\OrderDetails.cshtml"
                                  Write(Localizer["Quantity"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 57 "H:\Client\SimplCommerce\src\Modules\SimplCommerce.Module.Orders\Areas\Orders\Views\Order\OrderDetails.cshtml"
                                                         Write(item.Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                </div>\r\n                            </div>\r\n                        </td>\r\n                        <td class=\"text-right\">");
#nullable restore
#line 61 "H:\Client\SimplCommerce\src\Modules\SimplCommerce.Module.Orders\Areas\Orders\Views\Order\OrderDetails.cshtml"
                                          Write(item.ProductPriceString);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td class=\"text-right\">");
#nullable restore
#line 62 "H:\Client\SimplCommerce\src\Modules\SimplCommerce.Module.Orders\Areas\Orders\Views\Order\OrderDetails.cshtml"
                                          Write(item.Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td class=\"text-right\">");
#nullable restore
#line 63 "H:\Client\SimplCommerce\src\Modules\SimplCommerce.Module.Orders\Areas\Orders\Views\Order\OrderDetails.cshtml"
                                          Write(item.DiscountAmountString);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td class=\"text-right pr-0\">");
#nullable restore
#line 64 "H:\Client\SimplCommerce\src\Modules\SimplCommerce.Module.Orders\Areas\Orders\Views\Order\OrderDetails.cshtml"
                                               Write(item.RowTotalString);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n");
#nullable restore
#line 66 "H:\Client\SimplCommerce\src\Modules\SimplCommerce.Module.Orders\Areas\Orders\Views\Order\OrderDetails.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n        <div class=\"row\">\r\n            <div class=\"col-md-6\"></div>\r\n            <div class=\"col-md-6\">\r\n                <table class=\"table table-borderless\">\r\n                    <tr>\r\n                        <td>");
#nullable restore
#line 74 "H:\Client\SimplCommerce\src\Modules\SimplCommerce.Module.Orders\Areas\Orders\Views\Order\OrderDetails.cshtml"
                       Write(Localizer["Subtotal"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td class=\"text-right pr-0\">");
#nullable restore
#line 75 "H:\Client\SimplCommerce\src\Modules\SimplCommerce.Module.Orders\Areas\Orders\Views\Order\OrderDetails.cshtml"
                                               Write(Model.SubtotalString);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td>");
#nullable restore
#line 78 "H:\Client\SimplCommerce\src\Modules\SimplCommerce.Module.Orders\Areas\Orders\Views\Order\OrderDetails.cshtml"
                       Write(Localizer["Shipping"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td class=\"text-right pr-0\">");
#nullable restore
#line 79 "H:\Client\SimplCommerce\src\Modules\SimplCommerce.Module.Orders\Areas\Orders\Views\Order\OrderDetails.cshtml"
                                               Write(Model.ShippingAmountString);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td>");
#nullable restore
#line 82 "H:\Client\SimplCommerce\src\Modules\SimplCommerce.Module.Orders\Areas\Orders\Views\Order\OrderDetails.cshtml"
                       Write(Localizer["Tax"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td class=\"text-right pr-0\">");
#nullable restore
#line 83 "H:\Client\SimplCommerce\src\Modules\SimplCommerce.Module.Orders\Areas\Orders\Views\Order\OrderDetails.cshtml"
                                               Write(Model.TaxAmountString);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td>");
#nullable restore
#line 86 "H:\Client\SimplCommerce\src\Modules\SimplCommerce.Module.Orders\Areas\Orders\Views\Order\OrderDetails.cshtml"
                       Write(Localizer["Discount"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td class=\"text-right pr-0\">");
#nullable restore
#line 87 "H:\Client\SimplCommerce\src\Modules\SimplCommerce.Module.Orders\Areas\Orders\Views\Order\OrderDetails.cshtml"
                                               Write(Model.DiscountAmountString);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td>");
#nullable restore
#line 90 "H:\Client\SimplCommerce\src\Modules\SimplCommerce.Module.Orders\Areas\Orders\Views\Order\OrderDetails.cshtml"
                       Write(Localizer["Payment Fee"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td class=\"text-right pr-0\">");
#nullable restore
#line 91 "H:\Client\SimplCommerce\src\Modules\SimplCommerce.Module.Orders\Areas\Orders\Views\Order\OrderDetails.cshtml"
                                               Write(Model.PaymentFeeAmountString);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td><strong>");
#nullable restore
#line 94 "H:\Client\SimplCommerce\src\Modules\SimplCommerce.Module.Orders\Areas\Orders\Views\Order\OrderDetails.cshtml"
                               Write(Localizer["Order Total"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong></td>\r\n                        <td class=\"text-right pr-0\"><strong>");
#nullable restore
#line 95 "H:\Client\SimplCommerce\src\Modules\SimplCommerce.Module.Orders\Areas\Orders\Views\Order\OrderDetails.cshtml"
                                                       Write(Model.OrderTotalString);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong></td>\r\n                    </tr>\r\n                </table>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
        }
        #pragma warning restore 1998
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SimplCommerce.Module.Orders.Areas.Orders.ViewModels.OrderDetailVm> Html { get; private set; }
    }
}
#pragma warning restore 1591
