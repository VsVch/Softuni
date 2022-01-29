using TestMVCServer.Server.Http;

namespace TestMVCServer.Server.Results
{   

    public class ViewResult : ActionResult
    {
        private const char PathSeparator = '/';

        public ViewResult(
            HttpResponse response,
            string viewName,
            string controlerName,
            object model)
            : base(response)
        => this.GetHtml(viewName, controlerName, model);
       
        private void GetHtml(string viewName, string controlerName, object model) 
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

            if (model != null)
            {
                viewContent = this.PopulateModel(viewContent, model);
            }

            this.PrepareContent(viewContent, HttpContentType.Html);
           
        }

        private void PrepareMissingViewError(string viewPath) 
        {
            this.StatusCode = HttpStatusCode.NotFound;

            var errorMessaage = $"View '{viewPath}' was not found.";

            this.PrepareContent(errorMessaage, HttpContentType.PlainText);
        }

        private string PopulateModel(string viewContent, object model) 
        {
            var data = model
                 .GetType()
                 .GetProperties()
                 .Select(pr => new
                 {
                     Name = pr.Name,
                     Value = pr.GetValue(model)
                 });
            

            foreach (var entry in data)
            {
                const string openingBrackets = "{{";
                const string closingBrackets = "}}";

                viewContent = viewContent.Replace($"{openingBrackets}{entry.Name}{closingBrackets}", entry.Value.ToString());
            }

            return viewContent;
        }
    }
}
