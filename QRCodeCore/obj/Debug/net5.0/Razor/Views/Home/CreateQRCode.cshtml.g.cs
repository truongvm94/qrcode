#pragma checksum "D:\Workspace\QRCode\qrcode\QRCodeCore\Views\Home\CreateQRCode.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "60ffc929163ac1858e8a2ba3ce80144bc96ec2cf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_CreateQRCode), @"mvc.1.0.view", @"/Views/Home/CreateQRCode.cshtml")]
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
#line 1 "D:\Workspace\QRCode\qrcode\QRCodeCore\Views\_ViewImports.cshtml"
using QRCodeCore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Workspace\QRCode\qrcode\QRCodeCore\Views\_ViewImports.cshtml"
using QRCodeCore.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"60ffc929163ac1858e8a2ba3ce80144bc96ec2cf", @"/Views/Home/CreateQRCode.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9324d16a408bfe28f455058bea97e9595df6ec18", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_CreateQRCode : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<QRCodeCore.Models.QRCodeModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CreateQRCode", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Workspace\QRCode\qrcode\QRCodeCore\Views\Home\CreateQRCode.cshtml"
  
    ViewData["Title"] = "Quản lý công";

#line default
#line hidden
#nullable disable
            WriteLiteral("<hr />\r\n<div class=\"row\">\r\n    <div class=\"col-md-4\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "60ffc929163ac1858e8a2ba3ce80144bc96ec2cf3825", async() => {
                WriteLiteral("\r\n            <h1>");
#nullable restore
#line 10 "D:\Workspace\QRCode\qrcode\QRCodeCore\Views\Home\CreateQRCode.cshtml"
           Write(ViewBag.PathQr);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h1>\r\n            <div class=\"form-group\">\r\n\r\n                <img");
                BeginWriteAttribute("src", " src=\"", 283, "\"", 307, 1);
#nullable restore
#line 13 "D:\Workspace\QRCode\qrcode\QRCodeCore\Views\Home\CreateQRCode.cshtml"
WriteAttributeValue("", 289, ViewBag.QrCodeUri, 289, 18, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"img-thumbnail\" />\r\n            </div>\r\n            Mã QR sẽ hết hạn sau :\r\n            <label id=\"lblCountDown\" class=\"form-text text-danger d-inline\"></label>\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n</div>\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script language=""javaScript"" type=""text/javascript"">
        var i = 1;
        var _StartTime = ""300000""; //MiliSecound - Here it is 5 minutes
        var _seconds = 0;
        var _minutes = 0;
        var _hrs = 0;
        var pad = ""00"";
        setTimeout(""location.reload(true);"", _StartTime);
        function GetCount() {

            var _s = _StartTime;

            var ms = _s % 1000;
            _s = (_s - ms) / 1000;
            var _seconds = _s % 60;
            _s = (_s - _seconds) / 60;
            var _minutes = _s % 60;
            var _hrs = (_s - _minutes) / 60;

            var Sec = pad.substring(0, pad.length - String(_seconds).length) + _seconds;
            var Min = pad.substring(0, pad.length - String(_minutes).length) + _minutes;
            var Hr = pad.substring(0, pad.length - String(_hrs).length) + _hrs;

            document.getElementById('lblCountDown').innerText = Hr + "":"" + Min + "":"" + Sec;
            _StartTime = _StartTime - 1000;

      ");
                WriteLiteral("      if (_StartTime >= 0)\r\n                setTimeout(\"GetCount()\", 1000);\r\n        }\r\n        window.onload = GetCount;\r\n    </script>\r\n\r\n");
#nullable restore
#line 53 "D:\Workspace\QRCode\qrcode\QRCodeCore\Views\Home\CreateQRCode.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
#nullable disable
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<QRCodeCore.Models.QRCodeModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
