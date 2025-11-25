using Microsoft.AspNetCore.SignalR;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.Functions.Worker.SignalRService;


namespace AzFunctionWithSignalR
{

    [SignalRConnection("AzureSignalRConnectionString")]
    public class FunctionSignalR : ServerlessHub
    {
        private const string HubName = nameof(FunctionSignalR); // Used by SignalR trigger only

        public FunctionSignalR(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        [Function("negotiate")]
        public async Task<HttpResponseData> Negotiate([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequestData req)
        {
            var negotiateResponse = await NegotiateAsync(new() { UserId = req.Headers.GetValues("userId").FirstOrDefault() });
            var response = req.CreateResponse();
            response.WriteBytes(negotiateResponse.ToArray());
            return response;
        }

        //[Function("Broadcast")]
        //public Task Broadcast(
        //[SignalRTrigger(HubName, "messages", "broadcast", "message")] SignalRInvocationContext invocationContext, string message)
        //{
        //    return Clients.All.SendAsync("newMessage", new NewMessage(invocationContext, message));
        //}

        [Function("JoinGroup")]
        public Task JoinGroup([SignalRTrigger(HubName, "messages", "JoinGroup", "connectionId", "groupName")] SignalRInvocationContext invocationContext, string connectionId, string groupName)
        {
            return Groups.AddToGroupAsync(connectionId, groupName);
        }
    }
}
