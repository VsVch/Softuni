using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUS.mvcFramework.ViewEngine
{
    public class ErrorView : IView
    {
        private readonly IEnumerable<string> errors;
        private string csharpCode;
        public ErrorView(IEnumerable<string> errors, string csharpCode)
        {
            this.csharpCode = csharpCode;
            this.errors = errors;
        }
        public string ExecuteTemplate(object viewModel)
        {
            var html = new StringBuilder();
            html.AppendLine($"<h1>View compile errors: {this.errors.Count()}</h1><ul>");

            foreach (var error in this.errors)
            {
                html.AppendLine($"<li>{error}</li>");
            }
            html.AppendLine($"</ul><pre>{csharpCode}</pre>");

            return html.ToString();
        }
    }
}
