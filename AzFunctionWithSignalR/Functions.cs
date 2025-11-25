using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using System.Net;


namespace FunctionApp
{
    public class Functions
    {

        [Function("index")]
        public static HttpResponseData GetHomePage([HttpTrigger(AuthorizationLevel.Anonymous)] HttpRequestData req)
        {
            Console.WriteLine("Get HomePage");
            var response = req.CreateResponse(HttpStatusCode.OK);
            response.WriteString(File.ReadAllText("content/index.html"));
            response.Headers.Add("Content-Type", "text/html");
            Console.WriteLine("Get HomePage response");
            return response;
        }

        [Function("negotiate")]
        public static HttpResponseData Negotiate([HttpTrigger(AuthorizationLevel.Anonymous)] HttpRequestData req,
            [SignalRConnectionInfoInput(HubName = "serverless")] string connectionInfo)
        {
            Console.WriteLine("Negotiate");
            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "application/json");
            response.WriteString(connectionInfo);
            Console.WriteLine("Negotiate response");
            return response;
        }

    }
}