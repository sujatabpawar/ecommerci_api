#pragma checksum "H:\Client\SimplCommerce\src\Modules\SimplCommerce.Module.Reviews\Areas\Reviews\Views\Review\_ReviewFormSuccess.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5a482310ccaff9cac6b23f5fcd85563e9b8bcd78"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Reviews_Views_Review__ReviewFormSuccess), @"mvc.1.0.view", @"/Areas/Reviews/Views/Review/_ReviewFormSuccess.cshtml")]
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
#line 1 "H:\Client\SimplCommerce\src\Modules\SimplCommerce.Module.Reviews\Areas\Reviews\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "H:\Client\SimplCommerce\src\Modules\SimplCommerce.Module.Reviews\Areas\Reviews\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Mvc.Localization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "H:\Client\SimplCommerce\src\Modules\SimplCommerce.Module.Reviews\Areas\Reviews\Views\_ViewImports.cshtml"
using SimplCommerce.Module.Core.Extensions;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5a482310ccaff9cac6b23f5fcd85563e9b8bcd78", @"/Areas/Reviews/Views/Review/_ReviewFormSuccess.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7912926665090aba7b550a8348e2e574c887428f", @"/Areas/Reviews/Views/_ViewImports.cshtml")]
    public class Areas_Reviews_Views_Review__ReviewFormSuccess : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SimplCommerce.Module.Reviews.Areas.Reviews.ViewModels.ReviewForm>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"alert alert-success\" role=\"alert\">\r\n    <h4>\r\n        ");
#nullable restore
#line 5 "H:\Client\SimplCommerce\src\Modules\SimplCommerce.Module.Reviews\Areas\Reviews\Views\Review\_ReviewFormSuccess.cshtml"
   Write(Localizer["Thank you {0} for your review", Model.ReviewerName]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </h4>\r\n\r\n    <p>");
#nullable restore
#line 8 "H:\Client\SimplCommerce\src\Modules\SimplCommerce.Module.Reviews\Areas\Reviews\Views\Review\_ReviewFormSuccess.cshtml"
  Write(Localizer["Your review will be shown within the next 24h."]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SimplCommerce.Module.Reviews.Areas.Reviews.ViewModels.ReviewForm> Html { get; private set; }
    }
}
#pragma warning restore 1591
