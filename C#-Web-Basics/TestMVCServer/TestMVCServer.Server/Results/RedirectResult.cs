using TestMVCServer.Server.Http;

namespace TestMVCServer.Server.Results
{
    class RedirectResult : ActionResult
    {
        public RedirectResult(HttpResponse response, string location)
            : base(response)
        {
            this.StatusCode = HttpStatusCode.Found;

            this.AddHeader(HttpHeader.Location, location);
        }            
        
    }
}
