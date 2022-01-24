using TestMVCServer.Server.Http;

namespace TestMVCServer.Server.Responses
{
    class RedirectResponse : HttpResponse
    {
        public RedirectResponse(string location)
            : base(HttpStatusCode.Found) 
            => this.Headers.Add("Location", location);
        
    }
}
