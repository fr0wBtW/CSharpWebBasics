using SUS.HTTP;
using System.Text;

IHttpServer server = new HttpServer();
server.AddRoute("/joro", (request) =>
{
    return new HttpResponse("text/html", new byte[] {0x4d, 0x42, 0x2d, 0x42, 0x45, 0x4e, 0x5a});
});
server.AddRoute("/", (HomePage));
server.AddRoute("/favicon.ico", Favicon);
server.AddRoute("/about", About);
server.AddRoute("/users/login", Login);

  await server.StartAsync(80);

static HttpResponse HomePage(HttpRequest request)
{
    var responseHtml = "<h1> Welcome! </h1>" + request.Headers.FirstOrDefault(x => x.Name == "User-Agent")?.Value;
    var responeBodyBytes = Encoding.UTF8.GetBytes(responseHtml);
    var response = new HttpResponse("text/html", responeBodyBytes);

    return response;
}
static HttpResponse Favicon(HttpRequest request)
{
    var fileBytes = File.ReadAllBytes("wwwroot/favicon.ico");
    var response = new HttpResponse("image/vnd.microsoft.icon", fileBytes);
    return response;
}
static HttpResponse About(HttpRequest request)
{
    var responseHtml = "<h1> About... </h1>";
    var responeBodyBytes = Encoding.UTF8.GetBytes(responseHtml);
    var response = new HttpResponse("text/html", responeBodyBytes);

    return response;
}
static HttpResponse Login(HttpRequest request)
{
    var responseHtml = "<h1> Login... </h1>";
    var responeBodyBytes = Encoding.UTF8.GetBytes(responseHtml);
    var response = new HttpResponse("text/html", responeBodyBytes);

    return response;
}