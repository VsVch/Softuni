using TestMVCServer.Server.Http;

namespace TestMVCServer.Server.Results
{
    class NotFoundResult : ActionResult
    {
        public NotFoundResult(HttpResponse response)
            : base(response)
            => this.StatusCode = HttpStatusCode.NotFound;
        
    }
}
