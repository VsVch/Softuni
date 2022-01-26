using System;
using System.Collections.Generic;
using System.Linq;

namespace TestMVCServer.Server.Http
{
    public class HttpRequest
    {
        private const string NewLine = "\r\n";

        public HttpMethod Method { get; private set; }

        public string Path { get; private set; }

        public string Body { get; private set; }

        public IReadOnlyDictionary<string, string> Query { get; private set; }

        public IReadOnlyDictionary<string, string> Form { get; protected set; }
              
        public IReadOnlyDictionary<string, HttpHeader> Headers { get; private set; }
               
        public static HttpRequest Parse(string reqest)
        {
            var lines = reqest.Split(NewLine);

            var startLine = lines
                .First()
                .Split(" ");

            var method = ParseHttpMethod(startLine[0]);
            var url = startLine[1];

            var (path, query) = ParseUrl(url);

            var headersLine = lines.Skip(1);

            var headers = ParseHttpHeaders(headersLine);

            var body = string.Join(NewLine, lines.Skip(headers.Count + 2).ToArray());

            var form = ParseForm(headers, body);

            var newResponse = new HttpRequest
            {
                Method = method,
                Path = path,
                Query = query,
                Headers = headers,
                Body = body,
                Form = form,
            };

            return newResponse;

        }        

        private static new Dictionary<string, HttpHeader> ParseHttpHeaders(IEnumerable<string> headersLine)
        {
            var headersCollection = new Dictionary<string, HttpHeader>();

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

                headersCollection.Add(name, new HttpHeader(name, value));
            }

            return headersCollection;
        }

        private static HttpMethod ParseHttpMethod(string method)
            => method.ToUpper() switch
            {
                "GET" => HttpMethod.Get,
                "POST" => HttpMethod.Post,
                "PUT" => HttpMethod.Put,
                "DELETE" => HttpMethod.Delete,
                _ => throw new InvalidOperationException($"Method '{method}' is not supported")
            };

        private static (string, Dictionary<string, string>) ParseUrl(string url)
        {
            var urlParts = url.Split('?');

            var path = urlParts[0].ToLower();
            var query = urlParts.Length > 1
                ? ParseQuery(urlParts[1])
                : new Dictionary<string, string>(); ;

            return (path, query);
        }

        private static Dictionary<string, string> ParseQuery(string queryString)
            => queryString
                    .Split('&')
                    .Select(part => part.Split('='))
                    .Where(part => part.Length == 2)
                    .ToDictionary(k => k[0], v => v[1]);

        private static Dictionary<string, string> ParseForm(Dictionary<string, HttpHeader> headers, string body)
        {
            var result = new Dictionary<string, string>();

            if (headers.ContainsKey(HttpHeader.ContentType) 
                && headers[HttpHeader.ContentType].Value == HttpContentType.FormUrlEncoded)
            {
                result = ParseQuery(body);
            }

            return result;
        }

    }
}
