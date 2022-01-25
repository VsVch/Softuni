using TestMVCServer.Server.Http;
using TestMVCServer.Server.Responses;

namespace TestMVCServer.Server.Response
{
    public class TextResponse : ContentResponse
    {
        public TextResponse(string text)
            : base(text, HttpContentType.PlainText)
        {
        }
    }

}
