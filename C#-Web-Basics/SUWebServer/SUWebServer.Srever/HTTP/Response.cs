using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUWebServer.Srever.HTTP
{
    public class Response
    {
        public Response(StatusCode statusCode)
        {
            this.StatusCode = statusCode;

            this.Headers.Add("Server", "My Web Serevr");
            this.Headers.Add("Date", $"{DateTime.UtcNow}");
        }

        public StatusCode StatusCode { get; init; }

        public HeaderCollection Headers { get; } = new HeaderCollection();

        public string Body { get; set; }

        public static Request Parse(string request)
        {
            var line = request.Split("\r\n");

            return null;
        }
    }
}
