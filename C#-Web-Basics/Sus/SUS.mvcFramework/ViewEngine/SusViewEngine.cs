using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SUS.mvcFramework.ViewEngine
{
    public class SusViewEngine : IViewEngine
    {
        public string GetHtml(string tamplateCode, object viewModel)
        {
            string csharpCode = GenerateCSharpFromTemplate(tamplateCode);
            IView executableObject = GenerateExecutableCode(csharpCode, viewModel);
            string html = executableObject.ExecuteTemplate(viewModel);

            return html;
        }
        private string GenerateCSharpFromTemplate(string templateCode)
        {
            string methodBody = GetMethodBody(templateCode);
            string csharpCode = @"
using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using SUS.mvcFramework.ViewEngine;

namespace ViewNamespace
{
    public class ViewClass : IView
    {
        public string ExecuteTemplate(object viewModel)
        {
            var html = new StringBuilder();
            " + methodBody + @"

            retutn html.ToString();
        }
    }
}
";
            throw new NotImplementedException();
        }

        private string GetMethodBody(string templateCode)
        {
            return string.Empty;
        }

        private IView GenerateExecutableCode(string csharpCode, object viewModel)
        {
            var compileResult = CSharpCompilation.Create("ViewAssembly")
                .WithOptions(new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary))
                .AddReferences(MetadataReference.CreateFromFile(typeof(object).Assembly.Location))
                .AddReferences(MetadataReference.CreateFromFile(typeof(IView).Assembly.Location));
            if (viewModel != null)
            {
                compileResult =
                    compileResult.AddReferences(MetadataReference.CreateFromFile(viewModel.GetType().Assembly.Location));
            }

            var libralys = Assembly
                .Load(new AssemblyName("netstandart"))
                .GetReferencedAssemblies();

            foreach (var libraly in libralys)
            {
                compileResult = compileResult.
                    AddReferences(MetadataReference.CreateFromFile(Assembly.Load(libraly).Location));
            }

            compileResult = compileResult.AddSyntaxTrees(SyntaxFactory.ParseSyntaxTree(csharpCode));

            compileResult.Emit("view.dll");

            return null;
        }

       
    }
}
