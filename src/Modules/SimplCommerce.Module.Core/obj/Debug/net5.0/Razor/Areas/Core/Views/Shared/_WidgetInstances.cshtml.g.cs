#pragma checksum "F:\myecommerceapi\ecommerceapi\src\Modules\SimplCommerce.Module.Core\Areas\Core\Views\Shared\_WidgetInstances.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "62b51b3037c88315b5cacb870fcfcdb8c9a9b508"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Core_Views_Shared__WidgetInstances), @"mvc.1.0.view", @"/Areas/Core/Views/Shared/_WidgetInstances.cshtml")]
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
#line 1 "F:\myecommerceapi\ecommerceapi\src\Modules\SimplCommerce.Module.Core\Areas\Core\Views\_ViewImports.cshtml"
using SimplCommerce.Module.Core;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\myecommerceapi\ecommerceapi\src\Modules\SimplCommerce.Module.Core\Areas\Core\Views\_ViewImports.cshtml"
using SimplCommerce.Module.Core.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "F:\myecommerceapi\ecommerceapi\src\Modules\SimplCommerce.Module.Core\Areas\Core\Views\_ViewImports.cshtml"
using SimplCommerce.Module.Core.Areas.Core.ViewModels.Account;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "F:\myecommerceapi\ecommerceapi\src\Modules\SimplCommerce.Module.Core\Areas\Core\Views\_ViewImports.cshtml"
using SimplCommerce.Module.Core.Areas.Core.ViewModels.Manage;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "F:\myecommerceapi\ecommerceapi\src\Modules\SimplCommerce.Module.Core\Areas\Core\Views\_ViewImports.cshtml"
using SimplCommerce.Module.Core.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "F:\myecommerceapi\ecommerceapi\src\Modules\SimplCommerce.Module.Core\Areas\Core\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "F:\myecommerceapi\ecommerceapi\src\Modules\SimplCommerce.Module.Core\Areas\Core\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Mvc.Localization;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"62b51b3037c88315b5cacb870fcfcdb8c9a9b508", @"/Areas/Core/Views/Shared/_WidgetInstances.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"39ae4a4c81275951e35f765ffa4071b0e7b3dc51", @"/Areas/Core/Views/_ViewImports.cshtml")]
    public class Areas_Core_Views_Shared__WidgetInstances : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<SimplCommerce.Module.Core.Areas.Core.ViewModels.WidgetInstanceViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "F:\myecommerceapi\ecommerceapi\src\Modules\SimplCommerce.Module.Core\Areas\Core\Views\Shared\_WidgetInstances.cshtml"
 foreach (var widgetInstance in Model)
{
    if (widgetInstance.WidgetId == "HtmlWidget")
    {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "F:\myecommerceapi\ecommerceapi\src\Modules\SimplCommerce.Module.Core\Areas\Core\Views\Shared\_WidgetInstances.cshtml"
   Write(Html.Raw(widgetInstance.HtmlData));

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "F:\myecommerceapi\ecommerceapi\src\Modules\SimplCommerce.Module.Core\Areas\Core\Views\Shared\_WidgetInstances.cshtml"
                                          
    }
    else
    {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "F:\myecommerceapi\ecommerceapi\src\Modules\SimplCommerce.Module.Core\Areas\Core\Views\Shared\_WidgetInstances.cshtml"
   Write(await Component.InvokeAsync(widgetInstance.ViewComponentName, new { widgetInstance = widgetInstance }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "F:\myecommerceapi\ecommerceapi\src\Modules\SimplCommerce.Module.Core\Areas\Core\Views\Shared\_WidgetInstances.cshtml"
                                                                                                               
    }
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<SimplCommerce.Module.Core.Areas.Core.ViewModels.WidgetInstanceViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
