using SUS.mvcFramework.ViewEngine;
using System;
using System.IO;
using Xunit;

namespace SUS.MvcFramework.Tests
{
    public class SusViewEngineTests
    {
        [Theory]
        [InlineData("CleanHtml")]
        [InlineData("Foreach.html")]
        [InlineData("IfElseFor.html")]
        [InlineData("ViewModel.html")]
        public void TestGetHtml(string fileName)
        {
            var viewModel = new TestViewModel
            {
                DateOfBirth = new DateTime(2019, 6, 1),
                Name = "Sharo",
                Price = 500.20M
            };
            
            IViewEngine viewEngine = new SusViewEngine();
            var view = File.ReadAllText($"ViewTests/{fileName}.html");
            var result = viewEngine.GetHtml(view, viewModel);
            var expectedResult = File.ReadAllText($"ViewTests/{fileName}.Result.html");
            Assert.Equal(expectedResult, result);
        }
    }

    public class TestViewModel
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}
