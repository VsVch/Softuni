using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace ASP.netCoreTreningApp.Tests
{
    public class WebTests
    {
        [Fact]
        public async Task HomePageShoudeContainDevelopment()
        {
            var webApplicationFactory = new WebApplicationFactory<Program>();
            HttpClient client = webApplicationFactory.CreateClient();

            var response = await client.GetAsync("/");
            var html = await response.Content.ReadAsStringAsync();

            Assert.Contains("<p>Development environment</p>", html);
        }
    }
}
