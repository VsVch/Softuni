using TestMVCServer.Server.Common;
using TestMVCServer.Server.Http;
using TestMVCServer.Server.Responses;
using HttpMethod = TestMVCServer.Server.Http.HttpMethod;

namespace TestMVCServer.Server.Routing
{
    public class RoutingTable : IRoutingTable
    {
        private readonly Dictionary<HttpMethod, Dictionary<string, HttpResponse>> routes;

        public RoutingTable() => this.routes = new()
        {
            [HttpMethod.Get] = new (),
            [HttpMethod.Post] = new (),
            [HttpMethod.Put] = new (),
            [HttpMethod.Delete] = new (),
        };        

             
        public IRoutingTable Map(HttpMethod method, string path, HttpResponse response)
        {
            Guard.AgainstNull(path, nameof(path));
            Guard.AgainstNull(response, nameof(response));

            this.routes[method][path] = response;

            return this;
        }

        public IRoutingTable MapGet(string path, HttpResponse response)
         => Map(HttpMethod.Get, path, response);


        public IRoutingTable MapPost(string path, HttpResponse response)
         => Map(HttpMethod.Post, path, response);

        public HttpResponse MatchRequest(HttpRequest request)
        {
            var requestMethod = request.Method;
            var reqestPath = request.Path;

            if (!this.routes.ContainsKey(requestMethod)
                || !this.routes[requestMethod].ContainsKey(reqestPath))
            {
                return new NotFoundResponse();
            }

            return this.routes[requestMethod][reqestPath];
        }
    }
}
