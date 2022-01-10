using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;


namespace SUS.mvcFramework.ViewEngine
{
    public class SusViewEngine : IViewEngine
    {
        public string GetHtml(string tamplateCode, object viewModel)
        {
            string csharpCode = GenerateCSharpFromTemplate(tamplateCode, viewModel);
            IView executableObject = GenerateExecutableCode(csharpCode, viewModel);
            string html = executableObject.ExecuteTemplate(viewModel);

            return html;
        }
        private static string GenerateCSharpFromTemplate(string templateCode, object viewMode)
        {
            string typeOfModel = "object";
            if (viewMode != null)
            {
                if (viewMode.GetType().IsGenericType)
                {
                    var modelName = viewMode.GetType().FullName;
                    var genericArguments = viewMode.GetType().GenericTypeArguments;
                    typeOfModel = modelName.Substring(0, modelName.IndexOf('`'))
                        +"<" + string.Join(",", genericArguments.Select(x => x.FullName)) + ">";
                }
                else
                {
                    typeOfModel = viewMode.GetType().FullName;
                }
            }           
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
            var Model = viewModel as "+ typeOfModel + @";
            var html = new StringBuilder();
            " + GetMethodBody(templateCode) + @"
            return html.ToString();
        }
    }
}
";
            return csharpCode;
        }

        private static string GetMethodBody(string templateCode)
        {
            Regex csharpCodeRegex = new Regex(@"[^\""\s&\'\<]+");
            var suportedOperators = new List<string> { "for", "while", "if", "foreach", "else" };
            
            StringBuilder csharpCode = new ();
            StringReader sr = new (templateCode);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                if (suportedOperators.Any(x => line.TrimStart().StartsWith("@" + x)))
                {
                    var atSignLocation = line.IndexOf("@");
                    line = line.Remove(atSignLocation, 1);
                    csharpCode.AppendLine(line);
                }
                else if (line.TrimStart().StartsWith("{") ||
                    line.TrimStart().StartsWith("}"))
                {
                    csharpCode.AppendLine(line);
                }
                else
                {
                    csharpCode.Append($"html.AppendLine(@\"");

                    while (line.Contains("@"))
                    {
                        var atSignLocation = line.IndexOf("@");
                        var htmlBeforeAtSign = line.Substring(0, atSignLocation);
                        csharpCode.Append(htmlBeforeAtSign.Replace("\"", "\"\"") + "\" + ");
                        var lineAfterAtSign = line.Substring(atSignLocation + 1);
                        var code = csharpCodeRegex.Match(lineAfterAtSign).Value;
                        csharpCode.Append(code + " + @\"");
                        line = lineAfterAtSign.Substring(code.Length);
                    }               

                    csharpCode.AppendLine(line.Replace("\"", "\"\"") + "\");");
                }                
            }

            return csharpCode.ToString();
        }

        private static IView GenerateExecutableCode(string csharpCode, object viewModel)
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

            var libraries = Assembly.Load(
                new AssemblyName("netstandard"))
                .GetReferencedAssemblies();

            foreach (var libraly in libraries)
            {
                compileResult = compileResult.
                    AddReferences(MetadataReference.CreateFromFile(
                        Assembly.Load(libraly).Location));
            }

            compileResult = compileResult.AddSyntaxTrees(SyntaxFactory.ParseSyntaxTree(csharpCode));

            using MemoryStream memoryStream = new ();
            
                EmitResult result =
                    compileResult.Emit(memoryStream);

                if (!result.Success)
                {
                    return new ErrorView(result.Diagnostics
                        .Where(x => x.Severity == DiagnosticSeverity.Error)
                        .Select(x => x.GetMessage()), csharpCode);                        
                }

                try
                {
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    var byteAssembly = memoryStream.ToArray();
                    var assembly = Assembly.Load(byteAssembly);
                    var viewType = assembly.GetType("ViewNamespace.ViewClass");
                    var instance = Activator.CreateInstance(viewType);
                    return (instance as IView) ?? new ErrorView(new List<string> { "Instanse is null" }, csharpCode);
                }
                catch (Exception ex)
                {
                    return new ErrorView(new List<string> { ex.ToString() }, csharpCode);
                }              
                      
        }       
    }
}
