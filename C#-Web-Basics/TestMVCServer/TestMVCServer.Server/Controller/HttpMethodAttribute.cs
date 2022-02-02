using TestMVCServer.Server.Http;
using HttpMethod = TestMVCServer.Server.Http.HttpMethod;

namespace TestMVCServer.Server.Controller
{
    [AttributeUsage(AttributeTargets.Method)]
    public abstract class HttpMethodAttribute : Attribute
    {
        public HttpMethodAttribute(HttpMethod method)
        {
            this.HttpMethod = method;
        }
        public HttpMethod HttpMethod { get; }
    }
}
