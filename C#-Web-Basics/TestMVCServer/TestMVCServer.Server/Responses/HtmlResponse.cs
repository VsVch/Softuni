using TestMVCServer.Server.Http;

namespace TestMVCServer.Server.Responses
{
    public class HtmlResponse : ContentResponse
    {
        public HtmlResponse(string html)
            : base(html, HttpContentType.Html)
        {
        }
    }
}
