using HttpMethod = TestMVCServer.Server.Http.HttpMethod;

namespace TestMVCServer.Server.Controller
{
    public class HttpGetAttribute : HttpMethodAttribute
    {
        public HttpGetAttribute()
            : base(HttpMethod.Get)
        {
        }
    }
}
