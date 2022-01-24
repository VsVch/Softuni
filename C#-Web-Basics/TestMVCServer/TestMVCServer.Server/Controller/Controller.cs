using TestMVCServer.Server.Http;
using TestMVCServer.Server.Response;
using TestMVCServer.Server.Responses;

namespace TestMVCServer.Server.Controller
{
    public abstract class Controller
    {

        protected Controller(HttpRequest request)
            => this.Request = request;

        protected HttpRequest Request { get; private init; }

        protected HttpResponse Text(string text)
            => new TextResponse(text);

        protected HttpResponse Html(string html)
           => new HtmlResponse(html);

        protected HttpResponse Redirect(string location)
          => new RedirectResponse(location);
    }
}
