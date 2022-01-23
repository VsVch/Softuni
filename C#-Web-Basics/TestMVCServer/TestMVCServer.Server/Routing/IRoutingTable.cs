using TestMVCServer.Server.Http;
using HttpMethod = TestMVCServer.Server.Http.HttpMethod;

namespace TestMVCServer.Server.Routing
{
        public interface IRoutingTable
    {
        IRoutingTable Map(HttpMethod method, string path, HttpResponse response);
        IRoutingTable MapGet(string path, HttpResponse response);

        IRoutingTable MapPost(string url, HttpResponse response);
    }
}
