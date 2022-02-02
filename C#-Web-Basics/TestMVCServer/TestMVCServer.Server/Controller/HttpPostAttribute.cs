using HttpMethod = TestMVCServer.Server.Http.HttpMethod;

namespace TestMVCServer.Server.Controller
{
    public class HttpPostAttribute : HttpMethodAttribute
    {
        public HttpPostAttribute()
            : base(HttpMethod.Post)
        {
        }
    }
}
