
using TestMVCServer.Server.Http;

namespace TestMVCServer.Server.Responses
{
    public class BadRequestResponse : HttpResponse
    {
        public BadRequestResponse() 
            : base(HttpStatusCode.BadRequest)
        {
        }
    }
}
