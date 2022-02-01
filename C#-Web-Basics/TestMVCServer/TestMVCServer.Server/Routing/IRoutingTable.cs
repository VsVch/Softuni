using TestMVCServer.Server.Common;
using TestMVCServer.Server.Http;
using HttpMethod = TestMVCServer.Server.Http.HttpMethod;

namespace TestMVCServer.Server.Routing
{
    public interface IRoutingTable
    {
        IRoutingTable MapStaticFiles(string folder = Settings.StaticFilesRootFolder);

        IRoutingTable Map(HttpMethod method, string path, HttpResponse response);
        IRoutingTable Map(HttpMethod method, string path, Func<HttpRequest, HttpResponse> responseFunction);

        IRoutingTable MapGet(string path, HttpResponse response);       
        IRoutingTable MapGet(string path, Func<HttpRequest, HttpResponse> responseFunction);
       

        IRoutingTable MapPost(string url, HttpResponse response);
        IRoutingTable MapPost(string path, Func<HttpRequest, HttpResponse> responseFunction);
        
    }
}
