using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using System.Security.Claims;

namespace FunctionApp
{
    public class SimpleChat : ServerlessHub
    {

        [Function("index")]
        public IActionResult GetHomePage([HttpTrigger(AuthorizationLevel.Anonymous)]HttpRequest req, Microsoft.Azure.WebJobs.ExecutionContext context)
        {
            var path = Path.Combine(context.FunctionAppDirectory, "content", "index.html");
            Console.WriteLine(path);
            return new ContentResult
            {
                Content = File.ReadAllText(path),
                ContentType = "text/html",
            };
        }

        [Function("negotiate")]
        public SignalRConnectionInfo Negotiate([HttpTrigger(AuthorizationLevel.Anonymous)]HttpRequest req)
        {
            var claims = GetClaims(req.Headers["Authorization"]);
            return Negotiate(
                claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value,
                claims
            );
        }

    }
}