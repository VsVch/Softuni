namespace TestMVCServer.Server.Http
{
    public class HttpRequest
    {
        private const string NewLine = "\r\n";
              
        public HttpMethod Method { get; init; }

        public string Url { get; init; }

        public string Body { get; private set; } 

        public HttpHeaderCollection Headers { get; private set; } 

        public static HttpRequest Parse(string reqest) 
        {
            var lines = reqest.Split(NewLine);

            var startLine = lines
                .First()
                .Split(" ");

            var method = ParseHttpMethod(startLine[0]);
            var url = startLine[1];                     

            var headersLine = lines.Skip(1);

            var headers = ParseHttpHeaders(headersLine);

            var body = string.Join(NewLine, lines.Skip(headers.Count + 2).ToArray());
            var newResponse = 
            new HttpRequest
            {
                Method = method,
                Url = url,                
                Headers = headers,
                Body = body,
            };

            return newResponse;
           
        }

        private static HttpHeaderCollection ParseHttpHeaders(IEnumerable<string> headersLine)
        {
            var headersCollection = new HttpHeaderCollection();

            foreach (var headerLine in headersLine)
            {
                if (headerLine == String.Empty)
                {
                    break;
                }

                var headerParts = headerLine.Split(":", 2);

                if (headerParts.Length != 2)
                {
                    throw new InvalidOperationException($"Request is not valid!");
                }
                
                var name = headerParts[0];
                var value = headerParts[1].Trim();

                var header = new HttpHeader
                {
                    Name = name,
                    Value = value,
                };

                headersCollection.Add(header);
            }

            return headersCollection;
        }
            
        public static HttpMethod ParseHttpMethod(string method)
            => method.ToUpper() switch
            {
                "GET" => HttpMethod.Get,
                "POST" => HttpMethod.Post,
                "PUT" => HttpMethod.Put,
                "DELETE" => HttpMethod.Delete,
                _ => throw new InvalidOperationException($"Method '{method}' is not supported")
            };

        //private static HttpMethod ParseHttpMethod(string method)
        //{
        //    HttpMethod httpMethod;
        //    switch (method.ToUpper())
        //    {
        //        case "GET":
        //            httpMethod = HttpMethod.Get;
        //            break;
        //        case "POST":
        //            httpMethod = HttpMethod.Post;
        //            break;
        //        case "PUT":
        //            httpMethod = HttpMethod.Put;
        //            break;
        //        case "DELETE":
        //            httpMethod = HttpMethod.Delete;
        //            break;
        //        default:
        //            throw new InvalidOperationException($"Method {method} is not supported");

        //    };

        //    return httpMethod;

        //}
    }
}
