using TestMVCServer.Server.Http;


namespace TestMVCServer.Server.Results
{
    public class TextResult : ContentResult
    {
        public TextResult(HttpResponse response, string text)
            : base(response, text, HttpContentType.PlainText)
        {
        }
    }

}
