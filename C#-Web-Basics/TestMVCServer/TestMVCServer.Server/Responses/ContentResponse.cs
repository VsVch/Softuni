using System.Text;
using TestMVCServer.Server.Common;
using TestMVCServer.Server.Http;

namespace TestMVCServer.Server.Responses
{
    public class ContentResponse : HttpResponse
    {
        public ContentResponse(string text, string contentType)
            : base(HttpStatusCode.OK)
        {
            Guard.AgainstNull(text);

            var contentLength = Encoding.UTF8.GetByteCount(text).ToString();

            this.Headers.Add("Content-Type", contentType);
            this.Headers.Add("Content-Length", contentLength);

            this.Content = text;
        }        
    }
}
