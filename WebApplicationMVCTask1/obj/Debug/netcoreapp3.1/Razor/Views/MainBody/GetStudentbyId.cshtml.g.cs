#pragma checksum "D:\AssignmentProject\VS2019Assignments\WebApplicationMVCTask1\Views\MainBody\GetStudentbyId.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d116d9bfa258d4cf67a487d00d143343e75e968f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_MainBody_GetStudentbyId), @"mvc.1.0.view", @"/Views/MainBody/GetStudentbyId.cshtml")]
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
#line 1 "D:\AssignmentProject\VS2019Assignments\WebApplicationMVCTask1\Views\_ViewImports.cshtml"
using WebApplicationMVCTask1;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\AssignmentProject\VS2019Assignments\WebApplicationMVCTask1\Views\_ViewImports.cshtml"
using WebApplicationMVCTask1.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d116d9bfa258d4cf67a487d00d143343e75e968f", @"/Views/MainBody/GetStudentbyId.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ff177f1b785b5ebbe6cce3ea88880f2a8737d850", @"/Views/_ViewImports.cshtml")]
    public class Views_MainBody_GetStudentbyId : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebApplicationMVCTask1.Models.StudentUser>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/Stylesheet.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("studentForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("margin-left:25%;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\AssignmentProject\VS2019Assignments\WebApplicationMVCTask1\Views\MainBody\GetStudentbyId.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!DOCTYPE html>\r\n\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d116d9bfa258d4cf67a487d00d143343e75e968f5443", async() => {
                WriteLiteral(@"
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <title>Edit Student Master</title>
    <link href=""https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css"" rel=""stylesheet""
          integrity=""sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC"" crossorigin=""anonymous"">
    <script src=""https://code.jquery.com/jquery-3.6.4.min.js""></script>
    <script src=""https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js""></script>
    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "d116d9bfa258d4cf67a487d00d143343e75e968f6272", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d116d9bfa258d4cf67a487d00d143343e75e968f8154", async() => {
                WriteLiteral("\r\n    <div class=\"container mt-5\">\r\n        <h2 style=\"color: #19234F;margin-left:25%;\"><b>Edit Student Master</b></h2>\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d116d9bfa258d4cf67a487d00d143343e75e968f8547", async() => {
                    WriteLiteral("\r\n            <div class=\"mb-3\" style=\"display:none;\">\r\n                <label class=\"form-label\"><b>Student ID</b></label>\r\n                <input type=\"text\" class=\"form-control\" id=\"StudentId\"");
                    BeginWriteAttribute("value", " value=\"", 1110, "\"", 1134, 1);
#nullable restore
#line 25 "D:\AssignmentProject\VS2019Assignments\WebApplicationMVCTask1\Views\MainBody\GetStudentbyId.cshtml"
WriteAttributeValue("", 1118, Model.StudentId, 1118, 16, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(" required>\r\n            </div>\r\n            <div class=\"mb-3\">\r\n                <label for=\"firstName\" class=\"form-label\"><b>First Name</b></label>\r\n                <input type=\"text\" class=\"form-control\" id=\"firstName\"");
                    BeginWriteAttribute("value", " value=\"", 1354, "\"", 1378, 1);
#nullable restore
#line 29 "D:\AssignmentProject\VS2019Assignments\WebApplicationMVCTask1\Views\MainBody\GetStudentbyId.cshtml"
WriteAttributeValue("", 1362, Model.FirstName, 1362, 16, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(" required>\r\n            </div>\r\n            <div class=\"mb-3\">\r\n                <label for=\"lastName\" class=\"form-label\"><b>Last Name</b></label>\r\n                <input type=\"text\" class=\"form-control\" id=\"lastName\"");
                    BeginWriteAttribute("value", " value=\"", 1595, "\"", 1618, 1);
#nullable restore
#line 33 "D:\AssignmentProject\VS2019Assignments\WebApplicationMVCTask1\Views\MainBody\GetStudentbyId.cshtml"
WriteAttributeValue("", 1603, Model.LastName, 1603, 15, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(" required>\r\n            </div>\r\n            <div class=\"mb-3\">\r\n                <label for=\"session\" class=\"form-label\"><b>Session</b></label>\r\n                <input type=\"text\" class=\"form-control\" id=\"session\"");
                    BeginWriteAttribute("value", " value=\"", 1831, "\"", 1853, 1);
#nullable restore
#line 37 "D:\AssignmentProject\VS2019Assignments\WebApplicationMVCTask1\Views\MainBody\GetStudentbyId.cshtml"
WriteAttributeValue("", 1839, Model.Session, 1839, 14, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(" required>\r\n            </div>\r\n\r\n            <div class=\"mb-3\">\r\n                <label for=\"email\" class=\"form-label\"><b>Email</b></label>\r\n                <input type=\"email\" class=\"form-control\" id=\"email\"");
                    BeginWriteAttribute("value", " value=\"", 2063, "\"", 2083, 1);
#nullable restore
#line 42 "D:\AssignmentProject\VS2019Assignments\WebApplicationMVCTask1\Views\MainBody\GetStudentbyId.cshtml"
WriteAttributeValue("", 2071, Model.Email, 2071, 12, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(" required>\r\n            </div>\r\n            <div class=\"mb-3\">\r\n                <label for=\"ContactNo\" class=\"form-label\"><b>Phone Number</b></label>\r\n                <input type=\"tel\" class=\"form-control\" id=\"ContactNo\"");
                    BeginWriteAttribute("value", " value=\"", 2304, "\"", 2328, 1);
#nullable restore
#line 46 "D:\AssignmentProject\VS2019Assignments\WebApplicationMVCTask1\Views\MainBody\GetStudentbyId.cshtml"
WriteAttributeValue("", 2312, Model.ContactNo, 2312, 16, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(" required>\r\n            </div>\r\n            <div class=\"mb-3 form-check\" style=\"display:flex;\">\r\n                <input type=\"checkbox\" class=\"form-check-input\" id=\"isActive\" name=\"isActive\" ");
#nullable restore
#line 49 "D:\AssignmentProject\VS2019Assignments\WebApplicationMVCTask1\Views\MainBody\GetStudentbyId.cshtml"
                                                                                          Write(Model.IsActive ? "checked" : "");

#line default
#line hidden
#nullable disable
                    WriteLiteral(@">&nbsp;&nbsp;
                <label class=""form-check-label"" for=""isActive""><b>Is Active</b></label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <input type=""checkbox"" class=""form-check-input"" id=""isDeleted"" name=""isDeleted"" ");
#nullable restore
#line 51 "D:\AssignmentProject\VS2019Assignments\WebApplicationMVCTask1\Views\MainBody\GetStudentbyId.cshtml"
                                                                                            Write(Model.IsDeleted ? "checked" : "");

#line default
#line hidden
#nullable disable
                    WriteLiteral(@">&nbsp;&nbsp;
                <label class=""form-check-label"" for=""isDeleted""><b>Is Deleted</b></label>

            </div>
            <button type=""button"" id=""update"">Update</button>
            <button type=""button"" class=""btn btn-danger"" id=""cancel"">Cancel</button>
        ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    </div>\r\n");
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
            WriteLiteral(@"
</html>


<script>
    $(document).ready(function () {
        $('#update').click(function (StudentId) {           
            let obj = {};
            debugger;        
            obj.StudentId = $(""#StudentId"").val();
            obj.FirstName = $(""#firstName"").val();
            obj.LastName = $(""#lastName"").val();
            obj.Session = $(""#session"").val();
            obj.Email = $(""#email"").val();
            obj.ContactNo = $(""#ContactNo"").val();
            obj.IsActive = $(""#isactive"").prop(""checked"");
            obj.IsDeleted = $(""#isDeleted"").prop(""checked"");
            
            $.ajax({
                url: ""/MainBody/UpdateStudent"",
                type: ""POST"",
                data: obj,
                success: function (data) {
                   
                    alert(JSON.stringify(data.message));
                    location.reload();
                    window.location.href = ""/MainBody/StudentList"";
                },
                error: fun");
            WriteLiteral("ction (err) {                 \r\n                    console.error(err.message);\r\n                },\r\n            });\r\n        });\r\n    });\r\n</script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebApplicationMVCTask1.Models.StudentUser> Html { get; private set; }
    }
}
#pragma warning restore 1591
