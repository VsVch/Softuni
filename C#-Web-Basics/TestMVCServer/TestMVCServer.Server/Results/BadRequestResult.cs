using TestMVCServer.Server.Http;

namespace TestMVCServer.Server.Results
{
    public class BadRequestResult : HttpResponse
    {
        public BadRequestResult() 
            : base(HttpStatusCode.BadRequest)
        {
        }
    }
}
