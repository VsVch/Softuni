using SUWebServer.Srever;
using SUWebServer.Srever.HTTP;
using SUWebServer.Srever.Responses;
using System.Net;

public class Startup
{
    private const string HtmlForm = @"<form action='/HTML' method='POST'>
    Name: <input type='text' name ='Name'/>
    Age: <input type='number' name ='Age'/>
    <input type='submit' value ='Save'>
</form>";

    private const string DownloadForm = @"<form action='/Content' method='POST'>
    <input type='submit' value ='Download Sites Content'/>    
</form>";

    private const string FileName = "content.txt";

    static async Task Main()
    {
        await DownloadSiteAsTextFile(Startup.FileName,
            new string[] { "https://judge.softuni.org/", "https://softuni.org/" });
        var server = new HttpServer(routes => routes
            .MapGet("/", new TextResponse("Hello from the server!"))
            .MapGet("/HTML", new TextResponse(Startup.HtmlForm))
            .MapGet("/Redirect", new RedirectResponse("https://softuni.bg/org/"))
            .MapPost("/HTML", new TextResponse("", Startup.AddFromDataAction))
            .MapGet("/Content", new HtmlResponse(Startup.DownloadForm))
            .MapPost("/Content", new TextFileResponse(Startup.FileName)));
       await server.Start();
    }



    private static void AddFromDataAction(Request request, Response response)
    {
        response.Body = "";

        foreach (var (key, value) in request.Form)
        {
            response.Body += $"{key} - {value}";
            response.Body += Environment.NewLine;
        }
    }

    private static async Task<string> DownloadWebSiteContent(string url)
    {
        var httpClient = new HttpClient();

        using (httpClient)
        {
            var response = await httpClient.GetAsync(url);

            var html = await response.Content.ReadAsStringAsync();

            return html.Substring(0, 2000);

        }
    }

    private static async Task DownloadSiteAsTextFile(
        string fileName, string[] urls)
    {
        var download = new List<Task<string>>();

        foreach (var url in urls)
        {
            download.Add(DownloadWebSiteContent(url));
        }
        var responses = await Task.WhenAll(download);

        var responseString = string.Join(
            Environment.NewLine + new String('-', 100),
            responses);

        await File.WriteAllTextAsync(fileName, responseString);
    }
}












