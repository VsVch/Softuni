namespace TestMVCServer.Server.Http
{

    public class HttpResponse
    {
        public StatusCode StatusCode { get; init; }

        public HttpHeaderCollection Headers { get; init; } = new HttpHeaderCollection();

        public string Content { get; init; }
    }
}
