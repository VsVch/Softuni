using SUS.HTTP;
using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace SUS.mvcFramework
{
    public abstract class Controller
    {

        public HttpResponse View([CallerMemberName]string path = null)
        {
            var layout = System.IO.File.ReadAllText("Views/Shared/_Layout.cshtml");

            var viewContent = System.IO.File.ReadAllText(
                "Views/"
                + this.GetType().Name.Replace("Controller", string.Empty)+
                "/" + path +".cshtml");

            var responseHtml = layout.Replace("@RenderBody()", viewContent);

            var responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);
            var response = new HttpResponse("text/html", responseBodyBytes);
            return response;
        }

        public HttpResponse File(string filePath, string contentType )
        {
            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            var response = new HttpResponse(contentType, fileBytes);

            return response;
        }
    }
}
