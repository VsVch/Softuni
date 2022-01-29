using TestMVCServer.Server.Http;

namespace TestMVCServer.Server.Results
{
    public class ContentResult : ActionResult
    {
        public ContentResult(
            HttpResponse response,
            string content,
            string contentType)
            : base(response)
        => PrepareContent(content, contentType);                     
                
    }
}
