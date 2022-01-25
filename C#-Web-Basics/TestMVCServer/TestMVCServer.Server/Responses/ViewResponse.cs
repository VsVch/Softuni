using System;
using System.Collections.Generic;
using System.IO;
using TestMVCServer.Server.Http;

namespace TestMVCServer.Server.Responses
{   

    public class ViewResponse : HttpResponse
    {
        private const char PathSeparator = '/';

        public ViewResponse(string viewName, string controlerName)
            : base(HttpStatusCode.OK)
        => this.GetHtml(viewName, controlerName);
       
        private void GetHtml(string viewName, string controlerName) 
        {          

            if (!viewName.Contains(PathSeparator))
            {
                viewName = controlerName + PathSeparator + viewName;
            }

           var viewPath = Path.GetFullPath("./Views/" + viewName.TrimStart(PathSeparator) + ".cshtml");

            if (!File.Exists(viewPath))
            {
                PrepareMissingViewError(viewPath);
            }

            var viewContent = File.ReadAllText(viewPath);

            this.PrepareContent(viewContent, HttpContentType.Html);
           
        }

        private void PrepareMissingViewError(string viewPath) 
        {
            this.StatusCode = HttpStatusCode.NotFound;

            var errorMessaage = $"View '{viewPath}' was not found.";

            this.PrepareContent(errorMessaage, HttpContentType.PlainText);
        }
    }
}
