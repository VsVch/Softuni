﻿namespace TestMVCServer.Server.Http
{
    public class HttpRequest
    {       

        private static Dictionary<string, HttpSession> Sessions = new();

        private const string NewLine = "\r\n";

        public HttpMethod Method { get; private set; }

        public string Path { get; private set; }

        public IReadOnlyDictionary<string, string> Query { get; private set; }

        public IReadOnlyDictionary<string, string> Form { get; protected set; }
              
        public IReadOnlyDictionary<string, HttpHeader> Headers { get; private set; }

        public IReadOnlyDictionary<string, HttpCookie> Cookies { get; private set; }

        public HttpSession Session { get; private set; }

        public string Body { get; private set; }

        public static HttpRequest Parse(string reqest)
        {
            var lines = reqest.Split(NewLine);

            var startLine = lines
                .First()
                .Split(" ");

            var method = ParseMethod(startLine[0]);
            var url = startLine[1];

            var (path, query) = ParseUrl(url);

            var headersLine = lines.Skip(1);

            var headers = ParseHeaders(headersLine);

            var cookies = ParseCookies(headers);

            var sesion = GetSession(cookies);

            var body = string.Join(NewLine, lines.Skip(headers.Count + 2).ToArray());

            var form = ParseForm(headers, body);

            var newResponse = new HttpRequest
            {
                Method = method,
                Path = path,
                Query = query,
                Headers = headers,
                Cookies = cookies,
                Session = sesion,
                Body = body,
                Form = form,
            };

            return newResponse;
        }
               
         private static HttpMethod ParseMethod(string method)
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

        private static Dictionary<string, HttpHeader> ParseHeaders(IEnumerable<string> headersLine)
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

        private static Dictionary<string, HttpCookie> ParseCookies(Dictionary<string, HttpHeader> headers)
        {
            var cookieCollection = new Dictionary<string, HttpCookie>();

            if (headers.ContainsKey(HttpHeader.Cookie))
            {
                var cookieHeader = headers[HttpHeader.Cookie];

                var allCookies = cookieHeader
                    .Value
                    .Split(';');

                foreach (var cookie in allCookies)
                {
                    var cookiePart = cookie.Split('=');

                    var cookieName = cookiePart[0].Trim();
                    var cookieValue = cookiePart[1].Trim();

                    cookieCollection.Add(cookieName, new HttpCookie(cookieName, cookieValue));
                }
            }

            return cookieCollection;
        }

        private static HttpSession GetSession(Dictionary<string, HttpCookie> cookies)
        {
            var sessionId = cookies.ContainsKey(HttpSession.SessionCookieName)
                ? cookies[HttpSession.SessionCookieName].Value
                : Guid.NewGuid().ToString();

            if (!Sessions.ContainsKey(sessionId))
            {
                Sessions[sessionId] = new HttpSession(sessionId) { IsNew = true};
            }

            return Sessions[sessionId];
        }

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
        private static Dictionary<string, string> ParseQuery(string queryString)
            => queryString
                    .Split('&')
                    .Select(part => part.Split('='))
                    .Where(part => part.Length == 2)
                    .ToDictionary(k => k[0], v => v[1]);

    }
}
