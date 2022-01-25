using System.Text;
using TestMVCServer.Server.Common;
using TestMVCServer.Server.Http;

namespace TestMVCServer.Server.Responses
{
    public class ContentResponse : HttpResponse
    {
        public ContentResponse(string content, string contentType)
            : base(HttpStatusCode.OK)
        => PrepareContent(content, contentType);                     
                
    }
}
