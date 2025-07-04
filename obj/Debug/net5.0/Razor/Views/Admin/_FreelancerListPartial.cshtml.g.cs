#pragma checksum "D:\Sana'a\GradFinalProject\GradFinalProject\Views\Admin\_FreelancerListPartial.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "c1c511f65c4e983e42c73253a7a096fcc533c48dd0d8c108ba136c4d8b0d8b6a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCoreGeneratedDocument.Views_Admin__FreelancerListPartial), @"mvc.1.0.view", @"/Views/Admin/_FreelancerListPartial.cshtml")]
namespace AspNetCoreGeneratedDocument
{
    #line default
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Mvc;
    using global::Microsoft.AspNetCore.Mvc.Rendering;
    using global::Microsoft.AspNetCore.Mvc.ViewFeatures;
    #line default
    #line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"c1c511f65c4e983e42c73253a7a096fcc533c48dd0d8c108ba136c4d8b0d8b6a", @"/Views/Admin/_FreelancerListPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"f68c967ecac2dee79a0753fe99077890945878b3e87c560bd67de47177eeb66f", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    internal sealed class Views_Admin__FreelancerListPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<
#nullable restore
#line 1 "D:\Sana'a\GradFinalProject\GradFinalProject\Views\Admin\_FreelancerListPartial.cshtml"
       IEnumerable<GradFinalProject.Models.Freelancer>

#line default
#line hidden
#nullable disable
    >
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<table class=""table table-bordered mt-4"">
    <div class=""d-flex justify-content-between align-items-center mb-3"">
        <h3 class=""mb-0"">Freelancers List</h3>
        <button onclick=""hideCustomersTable()"" class=""btn btn-danger btn-sm"">
            <i class=""fas fa-times""></i> Close
        </button>
    </div>
    <thead class=""table-light"">
        <tr>
            <th>ID</th>
            <th>Full Name</th>
            <th>Specialization</th>
            <th>City</th>
            <th>Email</th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 20 "D:\Sana'a\GradFinalProject\GradFinalProject\Views\Admin\_FreelancerListPartial.cshtml"
         foreach (var freelancer in Model)
        {

#line default
#line hidden
#nullable disable

            WriteLiteral("            <tr>\r\n                <td>");
            Write(
#nullable restore
#line 23 "D:\Sana'a\GradFinalProject\GradFinalProject\Views\Admin\_FreelancerListPartial.cshtml"
                     freelancer.Id

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</td>\r\n                <td>");
            Write(
#nullable restore
#line 24 "D:\Sana'a\GradFinalProject\GradFinalProject\Views\Admin\_FreelancerListPartial.cshtml"
                      freelancer.Customer?.FirstName ?? "No First Name"

#line default
#line hidden
#nullable disable
            );
            WriteLiteral(" ");
            Write(
#nullable restore
#line 24 "D:\Sana'a\GradFinalProject\GradFinalProject\Views\Admin\_FreelancerListPartial.cshtml"
                                                                           freelancer.Customer?.LastName ?? ""

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</td>\r\n                <td>");
            Write(
#nullable restore
#line 25 "D:\Sana'a\GradFinalProject\GradFinalProject\Views\Admin\_FreelancerListPartial.cshtml"
                     freelancer.Profession

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</td>\r\n                <td>");
            Write(
#nullable restore
#line 26 "D:\Sana'a\GradFinalProject\GradFinalProject\Views\Admin\_FreelancerListPartial.cshtml"
                      freelancer.Customer?.City ?? "No City"

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</td>\r\n                <td>");
            Write(
#nullable restore
#line 27 "D:\Sana'a\GradFinalProject\GradFinalProject\Views\Admin\_FreelancerListPartial.cshtml"
                      freelancer.Customer?.Email ?? "No Email"

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</td>\r\n            </tr>\r\n");
#nullable restore
#line 29 "D:\Sana'a\GradFinalProject\GradFinalProject\Views\Admin\_FreelancerListPartial.cshtml"
        }

#line default
#line hidden
#nullable disable

            WriteLiteral("    </tbody>\r\n</table>\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<GradFinalProject.Models.Freelancer>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
