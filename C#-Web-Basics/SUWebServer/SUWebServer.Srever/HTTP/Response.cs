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
            var lines = request.Split("\r\n");

            var startLine = lines.First().Split(" ");

            var method = ParseMethod(startLine[0]);
            var url = startLine[1];

            var headers = ParseHeaders(lines.Skip(1));

            var body = lines.Skip(headers.Count + 2).ToArray();

            return null;
        }

        private static HeaderCollection ParseHeaders(IEnumerable<string> headerLines)
        {
            var headerCollection = new HeaderCollection();

            foreach (var headerLine in headerLines)
            {
                if (headerLine == string.Empty)
                {
                    break;
                }

                var headerParts = headerLine.Split(":", 2);

                if (headerParts.Length != 2)
                {
                    throw new InvalidOperationException("request is not valid");
                }

                var headerName = headerParts[0];
                var headerValue = headerParts[1];

                headerCollection.Add(headerName, headerValue);                               
            }

            return headerCollection;
        }

        private static object ParseMethod(string method)
        {
            try
            {
                return (Method)Enum.Parse(typeof(Method), method, true);
            }
            catch (Exception)
            {

                throw new InvalidOperationException($"Method '{method}' is not supported");
            }
        }
    }
}
