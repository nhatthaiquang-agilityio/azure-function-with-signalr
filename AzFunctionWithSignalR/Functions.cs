using Azure;
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

        //[Function("broadcast")]
        //[SignalROutput(HubName = "serverless")]
        //public static async Task<SignalRMessageAction> Broadcast([TimerTrigger("*/5 * * * * *")] TimerInfo timerInfo)
        //{
        //    var request = new HttpRequestMessage(HttpMethod.Get, "https://api.github.com/repos/azure/azure-signalr");
        //    request.Headers.UserAgent.ParseAdd("Serverless");
        //    request.Headers.Add("If-None-Match", Etag);
        //    var response = await HttpClient.SendAsync(request);
        //    if (response.Headers.Contains("Etag"))
        //    {
        //        Etag = response.Headers.GetValues("Etag").First();
        //    }
        //    if (response.StatusCode == HttpStatusCode.OK)
        //    {
        //        var result = await response.Content.ReadFromJsonAsync<GitResult>();
        //        if (result != null)
        //        {
        //            StarCount = result.StarCount;
        //        }
        //    }
        //    return new SignalRMessageAction("newMessage", new object[] { $"Current star count of https://github.com/Azure/azure-signalr is: {StarCount}" });
        //}

    }
}