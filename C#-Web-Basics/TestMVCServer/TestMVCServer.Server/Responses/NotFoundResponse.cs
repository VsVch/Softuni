using TestMVCServer.Server.Http;

namespace TestMVCServer.Server.Responses
{
    class NotFoundResponse : HttpResponse
    {
        public NotFoundResponse()
            : base(HttpStatusCode.NotFound)
        {
        }
    }
}
