using TestMVCServer.Server.Http;

namespace TestMVCServer.Server.Results
{
    public class HtmlResult : ContentResult
    {
        public HtmlResult(HttpResponse response, string html)
            : base(response, html, HttpContentType.Html)
        {
        }
    }
}
